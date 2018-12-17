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
    public class InstractorController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: Instractor
        public ActionResult Index()
        {
           // var instractors = db.Instractors.Include(i => i.Gender).Include(i => i.InstractorStatus);
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Instractors.ToList();
                return View(query);
            }
             

            //return View(instractors.ToList());
        }
        public ActionResult Main()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Instractors.ToList();
                return View(query);
            }
        }
        // GET: Instractor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractors instractors = db.Instractors.Find(id);
            if (instractors == null)
            {
                return HttpNotFound();
            }
            return View(instractors);
        }

        // GET: Instractor/Create
        public ActionResult Create()
        {

            ViewBag.Instractor_GenderID = new SelectList(db.Gender, "ID", CourseSite.Common.UImanger.CurrentLang=="en"?"Gender_EngName": "Gender_AraName");
            ViewBag.Instractor_StatusID = new SelectList(db.InstractorStatus, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Status_EngName": "Status_AraName");
            return View();
        }

        // POST: Instractor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Instractor_EngName,Instractor_AraName,Instractor_Address,Instractor_Mobile,Instractor_phone,Instractor_Email,Instractor_StatusID,Instractor_GenderID,Instractor_Birthdate")] Instractors instractors)
        {
            if (ModelState.IsValid)
            {
                db.Instractors.Add(instractors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Instractor_GenderID = new SelectList(db.Gender, "ID", CourseSite.Common.UImanger.CurrentLang=="en"?"Gender_EngName": "Gender_AraName");
            ViewBag.Instractor_StatusID = new SelectList(db.InstractorStatus, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Status_EngName": "Status_AraName");
            return View(instractors);
        }

        // GET: Instractor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractors instractors = db.Instractors.Find(id);
            if (instractors == null)
            {
                return HttpNotFound();
            }
            ViewBag.Instractor_GenderID = new SelectList(db.Gender, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Gender_EngName" : "Gender_AraName");
            ViewBag.Instractor_StatusID = new SelectList(db.InstractorStatus, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Status_EngName": "Status_AraName");
            return View(instractors);
        }

        // POST: Instractor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Instractor_EngName,Instractor_AraName,Instractor_Address,Instractor_Mobile,Instractor_phone,Instractor_Email,Instractor_StatusID,Instractor_GenderID,Instractor_Birthdate")] Instractors instractors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instractors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Instractor_GenderID = new SelectList(db.Gender, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Gender_EngName" : "Gender_AraName");
            ViewBag.Instractor_StatusID = new SelectList(db.InstractorStatus, "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Status_EngName": "Status_AraName");
            return View(instractors);
        }

        // GET: Instractor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instractors instractors = db.Instractors.Find(id);
            if (instractors == null)
            {
                return HttpNotFound();
            }
            return View(instractors);
        }

        // POST: Instractor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instractors instractors = db.Instractors.Find(id);
            db.Instractors.Remove(instractors);
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
