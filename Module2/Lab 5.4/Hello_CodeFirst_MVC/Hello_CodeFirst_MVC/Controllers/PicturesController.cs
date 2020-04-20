using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Hello_CodeFirst_MVC.Models;

namespace Hello_CodeFirst_MVC.Controllers
{
    public class PicturesController : Controller
    {
        private PicturesDbContext db = new PicturesDbContext();

        // GET: Pictures
        public ActionResult Index()
        {
            return View(db.Pictures.ToList());
        }

        // GET: Pictures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // GET: Pictures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PictureID,PictureName,Author,Image")] Picture picture)
        {
            if (ModelState.IsValid)
            {
                //Load image  by default
                var PictDir = HttpContext.ApplicationInstance.Server.MapPath("~/Images");
                var file = PictDir + @"/Default_img.jpg";
                var FStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(FStream))
                {
                    imageData = binaryReader.ReadBytes((int)FStream.Length);
                }
                picture.Image = imageData;

                db.Pictures.Add(picture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(picture);
        }

        // GET: Pictures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PictureID,PictureName,Author,Image")] Picture picture)
        {
            HttpPostedFileBase hpf = Request.Files["hpf"] as HttpPostedFileBase;
            if (ModelState.IsValid)
            {               
                // For modifying image
                if (hpf != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(hpf.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(hpf.ContentLength);
                    }
                    picture.Image = imageData;
                }

                db.Entry(picture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(picture);
        }

        // GET: Pictures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Picture picture = db.Pictures.Find(id);
            if (picture == null)
            {
                return HttpNotFound();
            }
            return View(picture);
        }

        // POST: Pictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Picture picture = db.Pictures.Find(id);
            db.Pictures.Remove(picture);
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
