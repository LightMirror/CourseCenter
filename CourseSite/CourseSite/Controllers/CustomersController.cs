using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseSite.Models.DAL;
using System.IO;

namespace CourseSite.Controllers
{
    public class CustomersController : Controller
    {        

        // GET: Customers
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var customers = db.Customers.Include(c => c.Corporates).Include(c => c.CustomerStatus).Include(c => c.Gender);
                return View(customers.ToList());
            }
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Customers customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
                return View(customers);
            }
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Customer_CorporateID = new SelectList(db.Corporates.ToList(), "ID", "Corporates_EngName");
                ViewBag.Customer_statusID = new SelectList(db.CustomerStatus.ToList(), "ID", "Status_EngName");
                ViewBag.Customer_GenderId = new SelectList(db.Gender.ToList(), "ID", "Gender_EngName");
                return View();
            }
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Customer_EngName,Customer_AraName,Customer_Phone,Customer_Mobile,Customer_Birthdate,Customer_Address,Customer_Email,Customer_Comment,Customer_GenderId,Customer_imagePath,ImageUpload,Customer_Nid,Customer_CorporateID,Customer_statusID")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    db.Customers.Add(customers);
                    db.SaveChanges();
                    if (customers.ImageUpload != null && !string.IsNullOrEmpty(customers.ImageUpload.FileName))
                    {
                        string subPath = "~/Uploads/Photo/Cutomers/";
                        var filename = Path.GetFileName(customers.ImageUpload.FileName);
                        var formattedFileName = string.Format("{0}-{1}{2}"
                                                       , customers.Customer_EngName
                                                       , customers.ID
                                                       , Path.GetExtension(filename));
                        bool exists = System.IO.Directory.Exists(subPath);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(Server.MapPath("~/Uploads/Photo/Cutomers/"));
                        subPath = Path.Combine(subPath, formattedFileName);

                        var path = Server.MapPath(subPath);
                        customers.ImageUpload.SaveAs(path);
                        customers.Customer_imagePath = subPath;
                        db.Entry(customers).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Customer_CorporateID = new SelectList(db.Corporates.ToList(), "ID", "Corporates_EngName", customers.Customer_CorporateID);
                ViewBag.Customer_statusID = new SelectList(db.CustomerStatus.ToList(), "ID", "Status_EngName", customers.Customer_statusID);
                ViewBag.Customer_GenderId = new SelectList(db.Gender.ToList(), "ID", "Gender_EngName", customers.Customer_GenderId);
                return View(customers);
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Customers customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }

                ViewBag.Customer_CorporateID = new SelectList(db.Corporates.ToList(), "ID", "Corporates_EngName", customers.Customer_CorporateID);
                ViewBag.Customer_statusID = new SelectList(db.CustomerStatus.ToList(), "ID", "Status_EngName", customers.Customer_statusID);
                ViewBag.Customer_GenderId = new SelectList(db.Gender.ToList(), "ID", "Gender_EngName", customers.Customer_GenderId);
                return View(customers);
            }
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Customer_EngName,Customer_AraName,Customer_Phone,Customer_Mobile,Customer_Birthdate,Customer_Address,Customer_Email,Customer_Comment,Customer_GenderId,Customer_imagePath,Customer_Nid,Customer_CorporateID,Customer_statusID")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    db.Entry(customers).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                ViewBag.Customer_CorporateID = new SelectList(db.Corporates.ToList(), "ID", "Corporates_EngName", customers.Customer_CorporateID);
                ViewBag.Customer_statusID = new SelectList(db.CustomerStatus.ToList(), "ID", "Status_EngName", customers.Customer_statusID);
                ViewBag.Customer_GenderId = new SelectList(db.Gender.ToList(), "ID", "Gender_EngName", customers.Customer_GenderId);
                return View(customers);
            }
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Customers customers = db.Customers.Find(id);
                if (customers == null)
                {
                    return HttpNotFound();
                }
                return View(customers);
            }
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Customers customers = db.Customers.Find(id);
                db.Customers.Remove(customers);
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
