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
        private readonly MartineDbContext db = new MartineDbContext();

        // GET: Research
        public ActionResult Index()
        {
            ViewBag.UserId= User.Identity.GetUserId();
            return View(db.CardioParamResultWomen);
        }

        [HttpPost]
        public PartialViewResult Calculate(List<CardioParam> cardioParams, string userId)
        {
            SortedDictionary<double, byte> clustersDistance = new SortedDictionary<double, byte>();
            List<CardioParamResultWoman> cardioParamResultWomen = db.CardioParamResultWomen.ToList();
            ResultViewModel resultViewModel = new ResultViewModel();
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

            resultViewModel.Conclusion = result.Conclusion;
            resultViewModel.Recomendation = result.Recomendation;
            resultViewModel.NextConclusion = nextResult.Conclusion;
            resultViewModel.NextRecomendation = nextResult.Recomendation;

            foreach (var item in clustersDistance)
            {
                Debug.WriteLine(item.Value+".: "+item.Key);
            }
            Debug.WriteLine("-----------");

            TempData["cardioParams"] = cardioParams;
            TempData["clustersDistance"] = clustersDistance;

            return PartialView("_Calculate", resultViewModel);
        }

        public ActionResult Save()
        {
            var cardioParams = (List<CardioParam>)TempData["cardioParams"];
            var clustersDistance = (SortedDictionary<double, byte>)TempData["clustersDistance"];

            try
            {
                foreach (var item in cardioParams)
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
                    StudentId = cardioParams[0].StudentId,
                    ClusterWomanId = clustersDistance.Values.Select(t => t).ToArray()[0],
                    NextClusterWomanId = clustersDistance.Values.Select(t => t).ToArray()[1],
                    Dist = clustersDistance.Keys.Select(t => t).ToArray()[0],
                    NextDist = clustersDistance.Keys.Select(t => t).ToArray()[1]
                });


                db.SaveChanges();
                ViewBag.Status = "Данные успешно сохранены !";
                return PartialView("Save");
            }
            catch
            {
                ViewBag.Status = "Данные не были сохранены !";
                return PartialView("Save");
            }
        }

    }
}