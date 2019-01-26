using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public static class FAQsRoutines
    {
        public static List<DAL.FAQs> GetTopFAQsForMAin()
        {
            using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
            {
                return db.FAQs.ToList();
            }
        }
    }
}