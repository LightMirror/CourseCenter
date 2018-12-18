using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;
using CourseSite.Models;

namespace CourseSite.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Courses.Where(x => x.Course_StatusID == 1).ToList();
                return View(query);
            }
        }

        public PartialViewResult Courses()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var q = from s in db.Courses
                        select new
                        {
                            s.Course_EngName,
                            s.Course_EngSummary,
                            s.Course_ImgePath
                        };
                //CourseVM VMCors = new CourseVM();
                //var query = db.Courses.FirstOrDefault();
                //VMCors.CourseName = query.Course_EngName;
                //VMCors.CourseImg = query.Course_ImgePath;
                //VMCors.CourseSumery = query.Course_EngSummary;
                return PartialView("_Courses", q.ToList());
            }
        }

        public ActionResult CourseDetails(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                CourseVM VMCors = new CourseVM();
                var query = db.Courses.Where(x => x.ID == id).FirstOrDefault();
                VMCors.CourseName = query.Course_EngName;
                VMCors.CourseImg = query.Course_ImgePath;
                VMCors.CourseObjective = query.Course_EngObjective;
                VMCors.CourseSumery = query.Course_EngSummary;
                return PartialView(VMCors);
            }
        }
    }
}