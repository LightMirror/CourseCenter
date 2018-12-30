using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseSite.Models
{
    public class CourseRoutine
    {
        public static List<DAL.Courses> GetTopCoursesForMAin()
        {
            using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
            {
                return db.Courses.Take(6).ToList();
            }
        }

        public static List<DAL.Courses> GetTopCoursesForIndex()
        {
            try
            {
                using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
                {
                    return db.Courses.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static IEnumerable<DAL.Courses> GetAll()
        {
            try
            {
                using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
                {
                    return db.Courses.ToList();
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static DAL.Courses GetCourse(int CouseId)
        {
            try
            {
                using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
                {
                    return (db.Courses.Find(CouseId));
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static SelectList GetDDLCourseStatus()
        {
            using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
            {
               List<DAL.Course_status> Cst= new List<DAL.Course_status>();
                Cst.Add(new DAL.Course_status { Status_EngName =CourseSite.App_GlobalResources.Main.ChoseStatus, ID = 0 });
                Cst.AddRange(db.Course_status.ToList());
             return(   new SelectList(Cst, "ID", "Status_EngName"));
            }
        }


    }
}