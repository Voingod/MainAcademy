using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hello_CodeFirst_MVC_my.Models;

namespace Hello_CodeFirst_MVC_my.Controllers
{
    public class DescriptionsController : Controller
    {
        private PictureDbContext db = new PictureDbContext();

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

        // GET: Descriptions/Create
        public ActionResult Create()
        {
            ViewBag.PictureID = new SelectList(db.Pictures, "PictureID", "PictureName");
            return View();
        }

        //public ActionResult Create([Bind(Include = "DescriptionID,PictureID,DescriptionText")] Description description)
        //{
        //    ViewBag.PictureID = description.PictureID.ToString() == null ?
        //        new SelectList(db.Pictures, "PictureID", "PictureName") :
        //        new SelectList(db.Pictures.Where(s => s.PictureID == description.PictureID), "PictureID", "PictureName");

        //    return View(description);
        //}
        // POST: Descriptions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
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
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
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
        public ActionResult Find([Bind(Include = "DesriptionID, PictureID, DesriptionText")] Description description)
        {
            if (description.PictureID.ToString() == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var descriptions = db.Descriptions.Where(s => s.PictureID == description.PictureID);
            return View(descriptions.ToList());
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
