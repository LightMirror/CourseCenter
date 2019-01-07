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
using CourseSite.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace CourseSite.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        // GET: Customers
        [Authorize]
        public ActionResult Index()
        {
            using (CenterDBEntities db = new CenterDBEntities())
            {
                var customers = db.Customers.Include(c => c.Corporates).Include(c => c.CustomerStatus).Include(c => c.Gender);
                return View(customers.ToList());
            }
        }

        // GET: Customers/Details/5
        [Authorize]
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
        [Authorize]
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


        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Customer_EngName,Customer_AraName,Customer_Phone,Customer_Mobile,Customer_Birthdate,Customer_Address,Customer_Email,Customer_Comment,Customer_GenderId,Customer_imagePath,ImageUpload,Customer_Nid,Customer_CorporateID,Customer_statusID")] Customers customers)
        {
            try
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
                        string DefaultPassword = "IATLa@"+customers.ID;
                        var user = new ApplicationUser { UserName = customers.Customer_Email, Email = customers.Customer_Email };
                        var result = UserManager.CreateAsync(user, DefaultPassword);
                        if (result.Result.Succeeded)
                        {
                            List<string> Recivers = new List<string>();
                            Recivers.Add(customers.Customer_Email);
                            string Body = "Welcome In IATLC Academy." + Environment.NewLine + "Your ID:" + customers.ID.ToString() + Environment.NewLine + "Emai: " + customers.Customer_Email + Environment.NewLine + "Password: " + DefaultPassword + Environment.NewLine + "Please save this message";
                            string Subject = "account credentials("+customers.Customer_EngName+")";
                            CourseSite.Common.Email.SendEmail(Recivers, Subject, Body);
                            CourseSite.Common.Email.SendWhatsapp("20" + customers.Customer_Mobile.ToString(), Body);

                            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                            // Send an email with this link
                            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                        }
                        else
                        {
                            db.Customers.Remove(customers);
                            db.SaveChanges();
                            TempData["Error"] = "Customer exist before, please change customer email and try again";
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
            catch(Exception ex)
            {
                CourseSite.Common.General.LogError(ex, "CustomersControllers.cs");
                using (CenterDBEntities db = new CenterDBEntities())
                {
                    ViewBag.Customer_CorporateID = new SelectList(db.Corporates.ToList(), "ID", "Corporates_EngName");
                    ViewBag.Customer_statusID = new SelectList(db.CustomerStatus.ToList(), "ID", "Status_EngName");
                    ViewBag.Customer_GenderId = new SelectList(db.Gender.ToList(), "ID", "Gender_EngName");
                    return View();
                }
            }
        }

        // GET: Customers/Edit/5
        [Authorize]
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
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Customer_EngName,Customer_AraName,Customer_Phone,Customer_Mobile,Customer_Birthdate,Customer_Address,Customer_Email,Customer_Comment,Customer_GenderId,Customer_imagePath,Customer_Nid,Customer_CorporateID,Customer_statusID")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                using (CenterDBEntities db = new CenterDBEntities())
                {

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
                    }
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


        // POST: Customers/Delete/5
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            
            using (CenterDBEntities db = new CenterDBEntities())
            {
                Customers customers = db.Customers.Find(id);
                var currentUser = UserManager.FindByEmail(customers.Customer_Email);
                db.Customers.Remove(customers);
                if(db.SaveChanges()>0)
                {
                    
                }
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
