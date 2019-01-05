using CourseSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public class CourseData
    {
        public Courses course { get; set; }
        public Groups group { get; set; }

    }
}