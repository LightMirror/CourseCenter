using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;
using CourseSite.Models;
using System.Net;
using System.Data.Entity;

namespace CourseSite.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                CourseVM vmCourse = new CourseVM();
                var query = db.Courses.Where(x => x.Course_StatusID == 1).ToList();
                return View(query);
            }
        }
        [HttpGet]
        public ActionResult ShowCourses()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Courses.ToList();
                return View(query);
            }
        }
        // GET: Cors/Details/5
        public ActionResult Details(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses courses = db.Courses.Find(id);
                if (courses == null)
                {
                    return HttpNotFound();
                }
                return View(courses);
            }
        }

        // GET: Cors/Create
        public ActionResult Create()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Course_StatusID = new SelectList(db.Course_status, "ID", "Status_EngName");
                return View();
            }
        }

        // POST: Cors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Course_EngName,Course_AraName,Course_VedioPath,Course_ImgePath,Course_ImagePath2,Course_EngObjective,Course_AraObjective,Course_EngSummary,Course_AraSummary,Course_ArabicContentPath,Course_EnglishContent,Course_StatusID,Course_TotalHour,Course_OrignalCost,Course_CreationDate,Course_CreationUsers,Course_ModifyDate,Course_modifyUsers")] Courses courses)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Courses.Add(courses);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Course_StatusID = new SelectList(db.Course_status, "ID", "Status_EngName", courses.Course_StatusID);
                return View(courses);
            }
        }

        // GET: Cors/Edit/5
        public ActionResult Edit(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses courses = db.Courses.Find(id);
                if (courses == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Course_StatusID = new SelectList(db.Course_status, "ID", "Status_EngName", courses.Course_StatusID);
                return View(courses);
            }
        }

        // POST: Cors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Course_EngName,Course_AraName,Course_VedioPath,Course_ImgePath,Course_ImagePath2,Course_EngObjective,Course_AraObjective,Course_EngSummary,Course_AraSummary,Course_ArabicContentPath,Course_EnglishContent,Course_StatusID,Course_TotalHour,Course_OrignalCost,Course_CreationDate,Course_CreationUsers,Course_ModifyDate,Course_modifyUsers")] Courses courses)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    db.Entry(courses).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Course_StatusID = new SelectList(db.Course_status, "ID", "Status_EngName", courses.Course_StatusID);
                return View(courses);
            }
        }

        // GET: Cors/Delete/5
        public ActionResult Delete(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses courses = db.Courses.Find(id);
                if (courses == null)
                {
                    return HttpNotFound();
                }
                return View(courses);
            }
        }

        // POST: Cors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Courses courses = db.Courses.Find(id);
                db.Courses.Remove(courses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    using (CenterDBEntities db = new CenterDBEntities())
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //        base.Dispose(disposing);
        //    }
        //}
        //public PartialViewResult Courses()
        //{
        //    using (CenterDBEntities db = new CenterDBEntities())
        //    {
        //        var q = from s in db.Courses
        //                select new
        //                {
        //                    s.Course_EngName,
        //                    s.Course_EngSummary,
        //                    s.Course_ImgePath
        //                };
        //        //CourseVM VMCors = new CourseVM();
        //        //var query = db.Courses.FirstOrDefault();
        //        //VMCors.CourseName = query.Course_EngName;
        //        //VMCors.CourseImg = query.Course_ImgePath;
        //        //VMCors.CourseSumery = query.Course_EngSummary;
        //        return PartialView("_Courses", q.ToList());
        //    }
        //}

        //public ActionResult CourseDetails(int id)
        //{
        //    using (CenterDBEntities db = new CenterDBEntities())
        //    {
        //        CourseVM VMCors = new CourseVM();
        //        var query = db.Courses.Where(x => x.ID == id).FirstOrDefault();
        //        VMCors.CourseName = query.Course_EngName;
        //        VMCors.CourseImg = query.Course_ImgePath;
        //        VMCors.CourseObjective = query.Course_EngObjective;
        //        VMCors.CourseSumery = query.Course_EngSummary;
        //        return PartialView(VMCors);
        //    }
        //}
    }
}