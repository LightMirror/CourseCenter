using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;

namespace CourseSite.Controllers
{
    public class schedulesController : Controller
    {

        // GET: schedules
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var schedules = db.schedules.Include(s => s.Groups);
                return View(schedules.ToList());
            }
           
        }

        // GET: schedules/Details/5
        public ActionResult Details(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                schedules schedules = db.schedules.Find(id);
                if (schedules == null)
                {
                    return HttpNotFound();
                }
                return View(schedules);
            }
        }

        // GET: schedules/Create
        public ActionResult Create()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser");
                return View();
            }
        }

        // POST: schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(schedules schedules)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    schedules.Schedule_CreationUser = User.Identity.Name;
                    schedules.Schedule_CreationDate = DateTime.Now;
                    db.schedules.Add(schedules);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", schedules.Schedule_GroupID);
                return View(schedules);
            }
        }

        // GET: schedules/Edit/5
        public ActionResult Edit(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                schedules schedules = db.schedules.Find(id);
                if (schedules == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", schedules.Schedule_GroupID);
                return View(schedules);
            }
        }

        // POST: schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(schedules schedules)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (ModelState.IsValid)
                {
                    schedules.Schedule_ModifiedUser = User.Identity.Name;
                    schedules.Schedule_ModifiedDate = DateTime.Now;
                    db.Entry(schedules).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", schedules.Schedule_GroupID);
                return View(schedules);
            }
        }

        // GET: schedules/Delete/5
        public ActionResult Delete(int? id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                schedules schedules = db.schedules.Find(id);
                if (schedules == null)
                {
                    return HttpNotFound();
                }
                return View(schedules);
            }
        }

        // POST: schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                schedules schedules = db.schedules.Find(id);
                db.schedules.Remove(schedules);
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
