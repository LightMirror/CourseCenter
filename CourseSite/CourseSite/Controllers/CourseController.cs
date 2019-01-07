using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;
using CourseSite.Models;
using System.Net;
using System.Data.Entity;
using System.IO;
using System.Drawing;

namespace CourseSite.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                MainViewModel MVM = new MainViewModel();
                MVM = CourseSite.Common.General.BuildMainView();
                MVM.Courses = CourseRoutine.GetTopCoursesForIndex();
                return View("Index", MVM);
            }
        }
        [HttpGet]
        public ActionResult ShowCourses()
        {
            return View(CourseRoutine.GetAll());
        }
        // GET: Cors/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Courses courses = CourseRoutine.GetCourse(id.Value);
                if (courses == null)
                {
                    return HttpNotFound();
                }
                return View(courses);
            }
            catch(Exception ex)
            {
                CourseSite.Common.General.LogError(ex, "CourseController.cs");
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }

        // GET: Cors/Create
        public ActionResult Create()
        {

            ViewBag.Course_StatusID = CourseRoutine.GetDDLCourseStatus();
                return View();
        }

        // POST: Cors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Course_EngName,Course_AraName,Course_VedioPath,Course_ImgePath,ImageUpload,Course_EngObjective,Course_AraObjective,Course_EngSummary,Course_AraSummary,Course_ArabicContentPath,Course_EnglishContent,Course_StatusID,Course_TotalHour,Course_OrignalCost")] Courses courses)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    courses.Course_CreationDate = DateTime.Now;
                    courses.Course_ModifyDate = DateTime.Now;                 
                    db.Courses.Add(courses);
                    db.SaveChanges();
                    if (courses.ImageUpload != null &&  !string.IsNullOrEmpty(courses.ImageUpload.FileName))
                    {
                        string subPath = "~/Uploads/Photo/Courses/";
                        var filename = Path.GetFileName(courses.ImageUpload.FileName);
                        var formattedFileName = string.Format("{0}-{1}{2}"
                                                       , courses.Course_EngName
                                                       , courses.ID
                                                       , Path.GetExtension(filename));
                        bool exists = System.IO.Directory.Exists(subPath);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Photo/Courses/"));
                        subPath = Path.Combine(subPath, formattedFileName);

                        var path = Server.MapPath(subPath);
                        courses.ImageUpload.SaveAs(path);
                        courses.Course_ImgePath = subPath;
                        db.Entry(courses).State = EntityState.Modified;
                        db.SaveChanges();
                    }         
                    return RedirectToAction("Index");
                }

                ViewBag.Course_StatusID = CourseRoutine.GetDDLCourseStatus();
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
                ViewBag.Course_StatusID = CourseRoutine.GetDDLCourseStatus();
                return View(courses);
            }
        }

        // POST: Cors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Course_EngName,Course_AraName,Course_VedioPath,Course_ImgePath,ImageUpload,Course_ImagePath2,Course_EngObjective,Course_AraObjective,Course_EngSummary,Course_AraSummary,Course_ArabicContentPath,Course_EnglishContent,Course_StatusID,Course_TotalHour,Course_OrignalCost,Course_CreationDate,Course_CreationUsers,Course_ModifyDate,Course_modifyUsers")] Courses courses)
        {
            try
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    if (ModelState.IsValid)
                    {
                        courses.Course_ModifyDate = DateTime.Now;
                        if (courses.ImageUpload != null && !string.IsNullOrEmpty(courses.ImageUpload.FileName))
                        {
                            string subPath = "~/Uploads/Photo/Courses/";
                            var filename = Path.GetFileName(courses.ImageUpload.FileName);
                            var formattedFileName = string.Format("{0}-{1}{2}"
                                                           , courses.Course_EngName
                                                           , courses.ID
                                                           , Path.GetExtension(filename));
                            bool exists = System.IO.Directory.Exists(subPath);
                            if (!exists)
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Photo/Courses/"));
                            subPath = Path.Combine(subPath, formattedFileName);

                            var path = Server.MapPath(subPath);
                            courses.ImageUpload.SaveAs(path);
                            courses.Course_ImgePath = subPath;
                        }
                        db.Entry(courses).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    ViewBag.Course_StatusID = CourseRoutine.GetDDLCourseStatus();
                    return View(courses);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        // GET: Cors/Delete/5
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

    }
}