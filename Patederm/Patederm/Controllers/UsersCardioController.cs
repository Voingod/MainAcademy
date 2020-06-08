using Microsoft.AspNet.Identity;
using Patederm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Patederm.Controllers
{
    public class UsersCardioController : Controller
    {
        private readonly MartineDbContext db = new MartineDbContext();
        // GET: UsersCardio
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var table = db.CardioParams.Join(db.ClusterStudents,
                c => c.StudentId,
                s => s.StudentId,
                (c, s) =>
                new UserCardioViewModel
                {
                    ADP = c.ADP,
                    ASP = c.ASP,
                    HR = c.HR,
                    Minute = c.Minute,
                    ClusterWomanId = s.ClusterWomanId,
                    Dist = s.Dist,
                    NextClusterWomanId = s.NextClusterWomanId,
                    NextDist = s.NextDist,
                    StudentId = s.StudentId,
                }).Where(s => s.StudentId == userId).ToList();

            return View(table);
        }
    }
}