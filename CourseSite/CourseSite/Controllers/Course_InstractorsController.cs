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
    public class Course_InstractorsController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: Course_Instractors
        public ActionResult Index()
        {
            var course_Instractors = db.Course_Instractors.Include(c => c.Courses).Include(c => c.Instractors).Include(c => c.Specifications);
            return View(course_Instractors.ToList());
        }

        // GET: Course_Instractors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Instractors course_Instractors = db.Course_Instractors.Find(id);
            if (course_Instractors == null)
            {
                return HttpNotFound();
            }
            return View(course_Instractors);
        }

        // GET: Course_Instractors/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Course_EngName");
            ViewBag.InstractorID = new SelectList(db.Instractors, "ID", "Instractor_EngName");
            ViewBag.SpecificationID = new SelectList(db.Specifications, "ID", "Specification_EngName");
            return View();
        }

        // POST: Course_Instractors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseID,InstractorID,SpecificationID")] Course_Instractors course_Instractors)
        {
            if (ModelState.IsValid)
            {
                db.Course_Instractors.Add(course_Instractors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Course_EngName", course_Instractors.CourseID);
            ViewBag.InstractorID = new SelectList(db.Instractors, "ID", "Instractor_EngName", course_Instractors.InstractorID);
            ViewBag.SpecificationID = new SelectList(db.Specifications, "ID", "Specification_EngName", course_Instractors.SpecificationID);
            return View(course_Instractors);
        }

        // GET: Course_Instractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Instractors course_Instractors = db.Course_Instractors.Find(id);
            if (course_Instractors == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Course_EngName", course_Instractors.CourseID);
            ViewBag.InstractorID = new SelectList(db.Instractors, "ID", "Instractor_EngName", course_Instractors.InstractorID);
            ViewBag.SpecificationID = new SelectList(db.Specifications, "ID", "Specification_EngName", course_Instractors.SpecificationID);
            return View(course_Instractors);
        }

        // POST: Course_Instractors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseID,InstractorID,SpecificationID")] Course_Instractors course_Instractors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Instractors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "ID", "Course_EngName", course_Instractors.CourseID);
            ViewBag.InstractorID = new SelectList(db.Instractors, "ID", "Instractor_EngName", course_Instractors.InstractorID);
            ViewBag.SpecificationID = new SelectList(db.Specifications, "ID", "Specification_EngName", course_Instractors.SpecificationID);
            return View(course_Instractors);
        }

        // GET: Course_Instractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Instractors course_Instractors = db.Course_Instractors.Find(id);
            if (course_Instractors == null)
            {
                return HttpNotFound();
            }
            return View(course_Instractors);
        }

        // POST: Course_Instractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Instractors course_Instractors = db.Course_Instractors.Find(id);
            db.Course_Instractors.Remove(course_Instractors);
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
