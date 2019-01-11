using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models;
using CourseSite.Models.DAL;
using Microsoft.AspNet.Identity;

namespace CourseSite.Controllers
{
    public class GroupsController : Controller
    {
       
        // GET: Groups
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var groups = db.Groups.Include(g => g.Course_Instractors).Include(g => g.GroupStatus);
                return View(groups.ToList());
            }
        }

        // GET: Groups/Details/5
        public ActionResult Details(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Groups groups = db.Groups.Find(id);
                if (groups == null)
                {
                    return HttpNotFound();
                }
                return View(groups);
            }
        }

        // GET: Groups/Create
        public ActionResult Create()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Group_CourseInstractorID = new SelectList(db.Course_Instractors, "ID", "ID");
                ViewBag.Group_statusID = new SelectList(db.GroupStatus, "ID", "GroupStatus_EngName");
                return View();
            }
        }

        // POST: Groups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Groups groups)
        {
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    groups.Group_CreationUser = User.Identity.Name;
                    groups.Group_CreationDate = DateTime.Now;
                    db.Groups.Add(groups);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Group_CourseInstractorID = new SelectList(db.Course_Instractors, "ID", "ID", groups.Group_CourseInstractorID);
                ViewBag.Group_statusID = new SelectList(db.GroupStatus, "ID", "GroupStatus_EngName", groups.Group_statusID);
                return View(groups);
            }
        }

        // GET: Groups/Edit/5
        public ActionResult Edit(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Groups groups = db.Groups.Find(id);
                if (groups == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Group_CourseInstractorID = new SelectList(db.Course_Instractors, "ID", "ID", groups.Group_CourseInstractorID);
                ViewBag.Group_statusID = new SelectList(db.GroupStatus, "ID", "GroupStatus_EngName", groups.Group_statusID);
                return View(groups);
            }
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Groups groups)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    groups.Group_modifiedUser = User.Identity.Name;
                    groups.Group_modifiedDate = DateTime.Now;
                    db.Entry(groups).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Group_CourseInstractorID = new SelectList(db.Course_Instractors, "ID", "ID", groups.Group_CourseInstractorID);
                ViewBag.Group_statusID = new SelectList(db.GroupStatus, "ID", "GroupStatus_EngName", groups.Group_statusID);
                return View(groups);
            }
        }

        // GET: Groups/Delete/5
        public ActionResult Delete(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Groups groups = db.Groups.Find(id);
                if (groups == null)
                {
                    return HttpNotFound();
                }
                return View(groups);
            }
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Groups groups = db.Groups.Find(id);
                db.Groups.Remove(groups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
}
