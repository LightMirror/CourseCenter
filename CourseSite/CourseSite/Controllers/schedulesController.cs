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
        private CenterDBEntities db = new CenterDBEntities();

        // GET: schedules
        public ActionResult Index()
        {
            var schedules = db.schedules.Include(s => s.Groups);
            return View(schedules.ToList());
        }

        // GET: schedules/Details/5
        public ActionResult Details(int? id)
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

        // GET: schedules/Create
        public ActionResult Create()
        {
            ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser");
            return View();
        }

        // POST: schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Schedule_ID,Schedule_GroupID,Schedule_DatetimeFrom,Schedule_DateTimeTo,Schedule_CreationDate,Schedule_CreationUser,Schedule_ModifiedDate,Schedule_ModifiedUser")] schedules schedules)
        {
            if (ModelState.IsValid)
            {
                db.schedules.Add(schedules);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", schedules.Schedule_GroupID);
            return View(schedules);
        }

        // GET: schedules/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Schedule_ID,Schedule_GroupID,Schedule_DatetimeFrom,Schedule_DateTimeTo,Schedule_CreationDate,Schedule_CreationUser,Schedule_ModifiedDate,Schedule_ModifiedUser")] schedules schedules)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedules).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Schedule_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", schedules.Schedule_GroupID);
            return View(schedules);
        }

        // GET: schedules/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            schedules schedules = db.schedules.Find(id);
            db.schedules.Remove(schedules);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
