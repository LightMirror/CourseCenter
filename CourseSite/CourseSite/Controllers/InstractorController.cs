using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;
using CourseSite.Models;
using CourseSite.Common;
using System.IO;

namespace CourseSite.Controllers
{
    public class InstractorController : Controller
    {

        // GET: Instractor
        public ActionResult Index()
        {
            // var instractors = db.Instractors.Include(i => i.Gender).Include(i => i.InstractorStatus);
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Instractors.ToList();
                return View(query);
            }


            //return View(instractors.ToList());
        }
        public ActionResult Main()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var query = db.Instractors.ToList();
                return View(query);
            }
        }
        // GET: Instractor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Instractors instractors = db.Instractors.Include("InstractorStatus").Include("Gender").SingleOrDefault(x => x.ID == id.Value);

                if (instractors == null)
                {
                    return HttpNotFound();
                }
                return View(instractors);
            }
        }

        // GET: Instractor/Create
        public ActionResult Create()
        {

            ViewBag.Instractor_GenderID = UImanger.GenderDll();
            ViewBag.Instractor_StatusID = InstractorsRoutines.GetInstractorStatusDLL();
            return View();
        }

        // POST: Instractor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Instractor_EngName,Instractor_AraName,instractor_imagePath,,ImageUpload,Instractor_Address,Instractor_Mobile," + "Instractor_phone,Instractor_Email,Instractor_Facebook,instractor_twitter,Instractor_LinkedIn,Instractor_StatusID,Instractor_GenderID,Instractor_Birthdate,instractor_QualificationsEnglish")] Instractors instractors)
        {
            if (ModelState.IsValid)
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    db.Instractors.Add(instractors);
                    db.SaveChanges();
                    if (instractors.ImageUpload != null && !string.IsNullOrEmpty(instractors.ImageUpload.FileName))
                    {
                        string subPath = "~/Uploads/Photo/instractors/";
                        var filename = Path.GetFileName(instractors.ImageUpload.FileName);
                        var formattedFileName = string.Format("{0}-{1}{2}"
                                                       , instractors.Instractor_EngName
                                                       , instractors.ID
                                                       , Path.GetExtension(filename));
                        bool exists = System.IO.Directory.Exists(subPath);

                        if (!exists)
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Photo/instractors/"));
                        subPath = Path.Combine("~/Uploads/Photo/instractors/", formattedFileName);
                        var path = Server.MapPath(subPath);
                        instractors.ImageUpload.SaveAs(path);
                        instractors.instractor_imagePath = subPath;

                        db.Entry(instractors).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Instractor_GenderID = UImanger.GenderDll();
            ViewBag.Instractor_StatusID = InstractorsRoutines.GetInstractorStatusDLL();
            return View(instractors);
        }

        // GET: Instractor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Instractors instractors = db.Instractors.Find(id);
               
                if (instractors == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Instractor_GenderID = UImanger.GenderDll();
                ViewBag.Instractor_StatusID = InstractorsRoutines.GetInstractorStatusDLL();
                return View(instractors);
            }
        }

        // POST: Instractor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Instractor_EngName,Instractor_AraName,instractor_imagePath,,ImageUpload,Instractor_Address,Instractor_Mobile," + "Instractor_phone,Instractor_Email,Instractor_Facebook,instractor_twitter,Instractor_LinkedIn,Instractor_StatusID,Instractor_GenderID,Instractor_Birthdate,instractor_QualificationsEnglish")] Instractors instractors)
        {
            if (ModelState.IsValid)
            {
                string oldimagepath = "";
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    oldimagepath=db.Instractors.Where(x => x.ID == instractors.ID).SingleOrDefault().instractor_imagePath;
                }
                    using (CenterDBEntities db = new CenterDBEntities())
                {
                    if (instractors.ImageUpload != null && !string.IsNullOrEmpty(instractors.ImageUpload.FileName))
                    {
                        string subPath = "~/Uploads/Photo/instractors/";
                        var filename = Path.GetFileName(instractors.ImageUpload.FileName);
                        var formattedFileName = string.Format("{0}-{1}{2}"
                                                       , instractors.Instractor_EngName
                                                       , instractors.ID
                                                       , Path.GetExtension(filename));
                        bool exists = System.IO.Directory.Exists(subPath);

                        if (!exists)
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Photo/instractors/"));
                        subPath = Path.Combine("~/Uploads/Photo/instractors/", formattedFileName);
                        var path = Server.MapPath(subPath);
                        instractors.ImageUpload.SaveAs(path);
                        instractors.instractor_imagePath = subPath;                        
                    }
                    else
                    {

                        instractors.instractor_imagePath = oldimagepath;
                    }
                    db.Entry(instractors).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Instractor_GenderID = UImanger.GenderDll();
            ViewBag.Instractor_StatusID = InstractorsRoutines.GetInstractorStatusDLL();
            return View(instractors);
        }

        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Instractors instractors = db.Instractors.Find(id);
                db.Instractors.Remove(instractors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    db.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
