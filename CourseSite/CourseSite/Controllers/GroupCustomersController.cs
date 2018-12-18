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
    public class GroupCustomersController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: GroupCustomers
        public ActionResult Index()
        {
            var groupCustomers = db.GroupCustomers.Include(g => g.Customers).Include(g => g.Groups);
            return View(groupCustomers.ToList());
        }

        // GET: GroupCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupCustomers groupCustomers = db.GroupCustomers.Find(id);
            if (groupCustomers == null)
            {
                return HttpNotFound();
            }
            return View(groupCustomers);
        }

        // GET: GroupCustomers/Create
        public ActionResult Create()
        {
            ViewBag.GroupCustomer_CustomerID = new SelectList(db.Customers, "ID", "Customer_EngName");
            ViewBag.GroupCustomer_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser");
            return View();
        }

        // POST: GroupCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupCustomer_ID,GroupCustomer_CustomerID,GroupCustomer_GroupID,GroupCustomer_payingCost")] GroupCustomers groupCustomers)
        {
            if (ModelState.IsValid)
            {
                db.GroupCustomers.Add(groupCustomers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupCustomer_CustomerID = new SelectList(db.Customers, "ID", "Customer_EngName", groupCustomers.GroupCustomer_CustomerID);
            ViewBag.GroupCustomer_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", groupCustomers.GroupCustomer_GroupID);
            return View(groupCustomers);
        }

        // GET: GroupCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupCustomers groupCustomers = db.GroupCustomers.Find(id);
            if (groupCustomers == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupCustomer_CustomerID = new SelectList(db.Customers, "ID", "Customer_EngName", groupCustomers.GroupCustomer_CustomerID);
            ViewBag.GroupCustomer_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", groupCustomers.GroupCustomer_GroupID);
            return View(groupCustomers);
        }

        // POST: GroupCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupCustomer_ID,GroupCustomer_CustomerID,GroupCustomer_GroupID,GroupCustomer_payingCost")] GroupCustomers groupCustomers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupCustomers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupCustomer_CustomerID = new SelectList(db.Customers, "ID", "Customer_EngName", groupCustomers.GroupCustomer_CustomerID);
            ViewBag.GroupCustomer_GroupID = new SelectList(db.Groups, "Group_ID", "Group_CreationUser", groupCustomers.GroupCustomer_GroupID);
            return View(groupCustomers);
        }

        // GET: GroupCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupCustomers groupCustomers = db.GroupCustomers.Find(id);
            if (groupCustomers == null)
            {
                return HttpNotFound();
            }
            return View(groupCustomers);
        }

        // POST: GroupCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupCustomers groupCustomers = db.GroupCustomers.Find(id);
            db.GroupCustomers.Remove(groupCustomers);
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
