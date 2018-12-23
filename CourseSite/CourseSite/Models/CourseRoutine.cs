using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}