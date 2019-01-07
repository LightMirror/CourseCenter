using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public class MainViewModel
    {
        public List<DAL.FAQs> Faqs { get; set; }

        public List<DAL.Courses> Courses { get; set; }

        public List<DAL.Gallary> Gallary { get; set; }
        public List<DAL.Instractors> Instarctors { get; set; }
    }
}