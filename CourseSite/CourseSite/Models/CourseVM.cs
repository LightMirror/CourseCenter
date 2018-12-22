using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public class CourseVM
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string CourseImg { get; set; }
        public string CourseObjective { get; set; }
        public string CourseSumery { get; set; }
    }
}