using Patederm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Patederm.Controllers
{
    public class ResearchController : Controller
    {
        readonly MartineDbContext db = new MartineDbContext();
        static List<CardioParam> cardioParamsGlobal = new List<CardioParam>();
        static SortedDictionary<double, byte> clustersDistance;

        // GET: Research
        public ActionResult Index()
        {
            ViewBag.UserId= User.Identity.GetUserId();
            return View(db.CardioParamResultWomen);
        }

        [HttpPost]
        public ActionResult Calculate(List<CardioParam> cardioParams, string userId)
        {
            cardioParamsGlobal = cardioParams;
            List<CardioParamResultWoman> cardioParamResultWomen = db.CardioParamResultWomen.ToList();
            clustersDistance = new SortedDictionary<double, byte>();
            int clustersCount = cardioParamResultWomen.Select(m => m.ClusterWomanId).Distinct().Count();

            for (int i = 0; i < clustersCount; i++)
            {
                
                double distance = 0;
                var cardioParamResultWomenArray = cardioParamResultWomen
                    .Where(cl => cl.ClusterWomanId == i + 1).ToArray();

                for (int j = 0; j < cardioParamResultWomenArray.Length; j++)
                {
                    cardioParams[j].StudentId = userId;
                    int minute = cardioParamResultWomenArray[j].Minute;

                    double adp = Math.Pow(cardioParams[minute].ADP - cardioParamResultWomenArray[j].ADP, 2);
                    double asp = Math.Pow(cardioParams[minute].ASP - cardioParamResultWomenArray[j].ASP, 2);
                    double hr = Math.Pow(cardioParams[minute].HR - cardioParamResultWomenArray[j].HR, 2);

                    distance += adp + asp + hr;
                }
                if (!clustersDistance.ContainsKey(distance))
                {
                    clustersDistance.Add(distance, (byte)(i + 1));
                }
            }
            var enumerator = clustersDistance.GetEnumerator();
            enumerator.MoveNext();
            int clusterFound = enumerator.Current.Value;

            enumerator.MoveNext();
            int nextClusterFound = enumerator.Current.Value;

            var result = db.ClusterWomen
                .Where(cl => cl.Cluster == clusterFound).ToArray()[0];

            var nextResult = db.ClusterWomen
                .Where(cl => cl.Cluster == nextClusterFound).ToArray()[0];

            ViewBag.ResultConclusion = result.Conclusion;
            ViewBag.ResultRecomendation = result.Recomendation;
            ViewBag.NextResultConclusion = nextResult.Conclusion;
            ViewBag.NextResultRecomendation = nextResult.Recomendation;

            foreach (var item in clustersDistance)
            {
                Debug.WriteLine(item.Value+".: "+item.Key);
            }
            Debug.WriteLine("-----------");
            return PartialView();
        }

        public ActionResult Save()
        {
            try
            {
                foreach (var item in cardioParamsGlobal)
                {
                    db.CardioParams.Add(new CardioParam
                    {
                        ADP = item.ADP,
                        ASP = item.ASP,
                        HR = item.HR,
                        Minute = item.Minute,
                        StudentId = item.StudentId
                    });
                }

                db.ClusterStudents.Add(new ClusterStudent
                {
                    StudentId = cardioParamsGlobal[0].StudentId,
                    ClusterWomanId = clustersDistance.Values.Select(t => t).ToArray()[0],
                    NextClusterWomanId = clustersDistance.Values.Select(t => t).ToArray()[1],
                    Dist = clustersDistance.Keys.Select(t => t).ToArray()[0],
                    NextDist = clustersDistance.Keys.Select(t => t).ToArray()[1]
                });


                db.SaveChanges();
                ViewBag.Status = @"Данные успешно сохранены !";
                return PartialView("Save");
            }
            catch
            {
                ViewBag.Status = @"Данные не были сохранены !";
                return PartialView("Save");
            }
        }
    }
}