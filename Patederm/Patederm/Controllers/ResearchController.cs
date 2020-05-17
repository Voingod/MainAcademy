using Patederm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Patederm.Controllers
{
    public class ResearchController : Controller
    {
        readonly MartineDbContext db = new MartineDbContext();
        // GET: Research
        public ActionResult Index()
        {
            return View(db.CardioParamResultWomen);
        }

        [HttpPost]
        public ActionResult Calculate(List<CardioParam> cardioParams)
        {
            List<CardioParamResultWoman> cardioParamResultWomen = db.CardioParamResultWomen.ToList();
            SortedDictionary<double, int> clustersDistance = new SortedDictionary<double, int>();
            int clustersCount = cardioParamResultWomen.Select(m => m.ClusterWomanId).Distinct().Count();

            for (int i = 0; i < clustersCount; i++)
            {
                double distance = 0;
                var cardioParamResultWomenArray = cardioParamResultWomen
                    .Where(cl => cl.ClusterWomanId == i + 1).ToArray();

                for (int j = 0; j < cardioParamResultWomenArray.Length; j++)
                {
                    int minute = cardioParamResultWomenArray[j].Minute;

                    double adp = Math.Pow(cardioParams[minute].ADP - cardioParamResultWomenArray[j].ADP, 2);
                    double asp = Math.Pow(cardioParams[minute].ASP - cardioParamResultWomenArray[j].ASP, 2);
                    double hr = Math.Pow(cardioParams[minute].HR - cardioParamResultWomenArray[j].HR, 2);

                    distance += adp + asp + hr;
                }
                if (!clustersDistance.ContainsKey(distance))
                {
                    clustersDistance.Add(distance, i + 1);
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

            return PartialView();
        }
    }
}