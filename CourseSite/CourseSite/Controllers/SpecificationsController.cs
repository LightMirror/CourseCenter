using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;

namespace CourseSite.Controllers
{
    public class SpecificationsController : Controller
    {

        // GET: Specifications
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                return View(db.Specifications.ToList());
            }
        }

        // GET: Specifications/Details/5
        public ActionResult Details(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Specifications specifications = db.Specifications.Find(id);
                if (specifications == null)
                {
                    return HttpNotFound();
                }
                return View(specifications);
            }
        }

        // GET: Specifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Specification_EngName,Specification_AraName,Specification_EngDescription,Specification_AraDescription")] Specifications specifications)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Specifications.Add(specifications);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(specifications);
            }
        }

        // GET: Specifications/Edit/5
        public ActionResult Edit(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Specifications specifications = db.Specifications.Find(id);
                if (specifications == null)
                {
                    return HttpNotFound();
                }
                return View(specifications);
            }
        }

        // POST: Specifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Specification_EngName,Specification_AraName,Specification_EngDescription,Specification_AraDescription")] Specifications specifications)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(specifications).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(specifications);
            }
        }

        // GET: Specifications/Delete/5
        public ActionResult Delete(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Specifications specifications = db.Specifications.Find(id);
                if (specifications == null)
                {
                    return HttpNotFound();
                }
                return View(specifications);
            }
        }

        // POST: Specifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Specifications specifications = db.Specifications.Find(id);
                db.Specifications.Remove(specifications);
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
    }
}
