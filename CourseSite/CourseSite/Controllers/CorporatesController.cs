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
    public class CorporatesController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: Corporates
        public ActionResult Index()
        {
            var corporates = db.Corporates.Include(c => c.CorporatesStatus).Include(c => c.CorporatesStatus1);
            return View(corporates.ToList());
        }

        // GET: Corporates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporates corporates = db.Corporates.Find(id);
            if (corporates == null)
            {
                return HttpNotFound();
            }
            return View(corporates);
        }

        // GET: Corporates/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.CorporatesStatus, "ID", "Status_EngName");
            ViewBag.Corporates_statusId = new SelectList(db.CorporatesStatus, "ID", "Status_EngName");
            return View();
        }

        // POST: Corporates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Corporates_EngName,Corporates_AraName,Corporates_Address,Corporates_phone,Corporates_mobile,Corporates_email,Corporates_FocalPoint,Corporates_Summary,Corporates_ImagePath1,Corporates_imagePath2,Corporates_statusId")] Corporates corporates)
        {
            if (ModelState.IsValid)
            {
                db.Corporates.Add(corporates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.ID);
            ViewBag.Corporates_statusId = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.Corporates_statusId);
            return View(corporates);
        }

        // GET: Corporates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporates corporates = db.Corporates.Find(id);
            if (corporates == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.ID);
            ViewBag.Corporates_statusId = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.Corporates_statusId);
            return View(corporates);
        }

        // POST: Corporates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Corporates_EngName,Corporates_AraName,Corporates_Address,Corporates_phone,Corporates_mobile,Corporates_email,Corporates_FocalPoint,Corporates_Summary,Corporates_ImagePath1,Corporates_imagePath2,Corporates_statusId")] Corporates corporates)
        {
            if (ModelState.IsValid)
            {
                db.Entry(corporates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.ID);
            ViewBag.Corporates_statusId = new SelectList(db.CorporatesStatus, "ID", "Status_EngName", corporates.Corporates_statusId);
            return View(corporates);
        }

        // GET: Corporates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Corporates corporates = db.Corporates.Find(id);
            if (corporates == null)
            {
                return HttpNotFound();
            }
            return View(corporates);
        }

        // POST: Corporates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Corporates corporates = db.Corporates.Find(id);
            db.Corporates.Remove(corporates);
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
