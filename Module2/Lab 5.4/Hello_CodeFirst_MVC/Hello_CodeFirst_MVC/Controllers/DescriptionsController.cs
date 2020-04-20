using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hello_CodeFirst_MVC.Models;

namespace Hello_CodeFirst_MVC.Controllers
{
    public class DescriptionsController : Controller
    {
        private PicturesDbContext db = new PicturesDbContext();

        // GET: Descriptions/Find/
        public ActionResult Find([Bind(Include = "DescriptionID,PictureID,DescriptionText")] Description descr)
        {
            if (descr.PictureID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var descriptions = db.Descriptions.Where(s => s.PictureID == descr.PictureID);
            return View(descriptions.ToList());
        }

        // GET: Descriptions
        public ActionResult Index()
        {
            var descriptions = db.Descriptions.Include(d => d.Picture);
            return View(descriptions.ToList());
        }

        // GET: Descriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        //// GET: Descriptions/Create
        //public ActionResult Create()
        //{
        //    ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName");
        //    return View();
        //}

        // GET: Descriptions/Create
        //[HttpGet]
        public ActionResult Create([Bind(Include = "DescriptionID,PictureID,DescriptionText")] Description description)
        {
            if (description.PictureID == null)
            {
                ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName");
            }
            else
            {
                ViewBag.PictureID = new SelectList(db.Pictures.Where(s => s.PictureID == description.PictureID), "PictureID", "PictureName");
            }
            return View();
        }


        // POST: Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult CreatePost([Bind(Include = "DescriptionID,PictureID,DescriptionText")] Description description)      
        {
            if (ModelState.IsValid)
            {
                db.Descriptions.Add(description);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", description.PictureID);
            return View(description);
        }

        // GET: Descriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", description.PictureID);
            return View(description);
        }

        // POST: Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DescriptionID,PictureID,DescriptionText")] Description description)
        {
            if (ModelState.IsValid)
            {
                db.Entry(description).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName", description.PictureID);
            return View(description);
        }

        // GET: Descriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Description description = db.Descriptions.Find(id);
            if (description == null)
            {
                return HttpNotFound();
            }
            return View(description);
        }

        // POST: Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Description description = db.Descriptions.Find(id);
            db.Descriptions.Remove(description);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
