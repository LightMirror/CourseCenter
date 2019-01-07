using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;

namespace CourseSite.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        [Authorize]
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                return View(db.Gallary.ToList());

            }
        }

        // GET: Gallery/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Gallary gallary = db.Gallary.Find(id);
                if (gallary == null)
                {
                    return HttpNotFound();
                }
                return View(gallary);
            }
        }

        // GET: Gallery/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Gallary gallary, HttpPostedFileBase file)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                string fileName = "";

                if (file != null && file.ContentLength > 0)
                {
                    string extention = Path.GetExtension(file.FileName);
                    fileName = DateTime.Now.Ticks.ToString() + extention;
                    var path = Path.Combine(Server.MapPath("~/Uploads/Gallary/"), fileName);

                    file.SaveAs(path);
                }
                gallary.ImagePath = fileName;

                if (ModelState.IsValid)
                {
                    db.Gallary.Add(gallary);
                    if (db.SaveChanges() > 0)
                    {
                        TempData["succed"] = "Succeed Add image ";
                    }
                    else
                    {
                        TempData["error"] = "Sorry we can not add image, Please try again later.";
                    }
                    return RedirectToAction("Index");
                }

                return View(gallary);
            }
        }

        [Authorize]
        public string ShowPhoto(int id)
        {
            if (ShowImage(id))
            {
                return "Photo showed successfully";
            }
            else
            {
                return "Something went wrong, Please try again later.";
            }
        }

        [Authorize]
        public string HidePhoto(int id)
        {
            if (HideImage(id))
            {
                return "Photo hided successfully";
            }
            else
            {
                return "Something went wrong, Please try again later.";
            }
        }

        [Authorize]
        private static bool ShowImage(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                try
                {
                    var query = db.Gallary.Where(x => x.ImageID == id).FirstOrDefault();
                    if (query != null)
                    {
                        query.ImageStatus = true;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        [Authorize]
        private static bool HideImage(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                try
                {
                    var query = db.Gallary.Where(x => x.ImageID == id).FirstOrDefault();
                    if (query != null)
                    {
                        query.ImageStatus = false;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return false;
        }

        [Authorize]
        // GET: Gallery/Edit/5
        public ActionResult Edit(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Gallary gallary = db.Gallary.Find(id);
                if (gallary == null)
                {
                    return HttpNotFound();
                }
                return View(gallary);
            }
        }

        // POST: Gallery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Gallary gallary, HttpPostedFileBase file)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                string fileName = "";

                if (file != null && file.ContentLength > 0)
                {
                    string extention = Path.GetExtension(file.FileName);
                    fileName = DateTime.Now.Ticks.ToString() + extention;
                    var path = Path.Combine(Server.MapPath("~/Uploads/Gallary/"), fileName);

                    file.SaveAs(path);
                }
                gallary.ImagePath = fileName;

                if (ModelState.IsValid)
                {
                    db.Entry(gallary).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)
                    {
                        TempData["succed"] = "Succeed modified image ";
                    }
                    else
                    {
                        TempData["error"] = "Sorry we can not add image, Please try again later.";
                    }
                    return RedirectToAction("Index");
                }
                return View(gallary);
            }
        }


        // GET: Gallery/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Gallary gallary = db.Gallary.Find(id);
                if (gallary == null)
                {
                    return HttpNotFound();
                }
                return View(gallary);
            }
        }

        // POST: Gallery/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Gallary gallary = db.Gallary.Find(id);
                db.Gallary.Remove(gallary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        public static List<Models.DAL.Gallary> GetActiveGallary()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                return (db.Gallary.Where(x => x.ImageStatus == true).ToList());

            }
        }
    }
}
