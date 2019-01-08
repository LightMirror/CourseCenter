using CourseSite.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseSite.Models
{
    public static class InstractorsRoutines
    {
        public static SelectList GetInstractorStatusDLL()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                return (new SelectList(db.InstractorStatus.ToList(), "ID", CourseSite.Common.UImanger.CurrentLang == "en" ? "Status_EngName" : "Status_AraName"));
            }
        }
        public static List<Instractors> GetAll()
        {
            using (DAL.CenterDBEntities db = new DAL.CenterDBEntities())
            {
                return db.Instractors.ToList();
            }
        }
    }
}