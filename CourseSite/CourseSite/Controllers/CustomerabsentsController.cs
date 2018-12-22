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
    public class CustomerabsentsController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: Customerabsents
        public ActionResult Index()
        {
            var customerabsent = db.Customerabsent.Include(c => c.GroupCustomers);
            return View(customerabsent.ToList());
        }

        // GET: Customerabsents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerabsent customerabsent = db.Customerabsent.Find(id);
            if (customerabsent == null)
            {
                return HttpNotFound();
            }
            return View(customerabsent);
        }

        // GET: Customerabsents/Create
        public ActionResult Create()
        {
            ViewBag.Customerabsent_GroupCustomerID = new SelectList(db.GroupCustomers, "GroupCustomer_ID", "GroupCustomer_ID");
            return View();
        }

        // POST: Customerabsents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customerabsent_ID,Customerabsent_Date,Customerabsent_ISabsent,Customerabsent_GroupCustomerID")] Customerabsent customerabsent)
        {
            if (ModelState.IsValid)
            {
                db.Customerabsent.Add(customerabsent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customerabsent_GroupCustomerID = new SelectList(db.GroupCustomers, "GroupCustomer_ID", "GroupCustomer_ID", customerabsent.Customerabsent_GroupCustomerID);
            return View(customerabsent);
        }

        // GET: Customerabsents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerabsent customerabsent = db.Customerabsent.Find(id);
            if (customerabsent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customerabsent_GroupCustomerID = new SelectList(db.GroupCustomers, "GroupCustomer_ID", "GroupCustomer_ID", customerabsent.Customerabsent_GroupCustomerID);
            return View(customerabsent);
        }

        // POST: Customerabsents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customerabsent_ID,Customerabsent_Date,Customerabsent_ISabsent,Customerabsent_GroupCustomerID")] Customerabsent customerabsent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerabsent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customerabsent_GroupCustomerID = new SelectList(db.GroupCustomers, "GroupCustomer_ID", "GroupCustomer_ID", customerabsent.Customerabsent_GroupCustomerID);
            return View(customerabsent);
        }

        // GET: Customerabsents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customerabsent customerabsent = db.Customerabsent.Find(id);
            if (customerabsent == null)
            {
                return HttpNotFound();
            }
            return View(customerabsent);
        }

        // POST: Customerabsents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customerabsent customerabsent = db.Customerabsent.Find(id);
            db.Customerabsent.Remove(customerabsent);
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
