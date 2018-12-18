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
    public class CompanyProfilesController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: CompanyProfiles
        public ActionResult Index()
        {
            return View(db.CompanyProfile.ToList());
        }

        // GET: CompanyProfiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfile companyProfile = db.CompanyProfile.Find(id);
            if (companyProfile == null)
            {
                return HttpNotFound();
            }
            return View(companyProfile);
        }

        [Authorize]
        // GET: CompanyProfiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyProfiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyNameEng,CompanyNameAra,CompanyAddress_FlatNumber,CompanyAddress_StreetNameEng,CompanyAddress_StreetNameAra,CompanyAddress_DistricNameEng,CompanyAddress_DistricNameAr,CompanyAddress_CityNameEng,CompanyAddress_CityNameAra,CompanyAddress_CountryNameEng,CompanyAddress_CountryNameAra,CompanyPhone1,CompanyPhone2,CompanyEmail,CompanySummarEng,CompanySummaryAra,CompanyVideoPath,CompanyImagePath,CompanyObjectiveEng,CompanyObjectiveAra,CompanyHeadLineEng,CompanyHeadLineAra,ID")] CompanyProfile companyProfile)
        {
            if (ModelState.IsValid)
            {
                db.CompanyProfile.Add(companyProfile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyProfile);
        }

        [Authorize]
        // GET: CompanyProfiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyProfile companyProfile = db.CompanyProfile.Find(id);
            if (companyProfile == null)
            {
                return HttpNotFound();
            }
            return View(companyProfile);
        }

        // POST: CompanyProfiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyNameEng,CompanyNameAra,CompanyAddress_FlatNumber,CompanyAddress_StreetNameEng,CompanyAddress_StreetNameAra,CompanyAddress_DistricNameEng,CompanyAddress_DistricNameAr,CompanyAddress_CityNameEng,CompanyAddress_CityNameAra,CompanyAddress_CountryNameEng,CompanyAddress_CountryNameAra,CompanyPhone1,CompanyPhone2,CompanyEmail,CompanySummarEng,CompanySummaryAra,CompanyVideoPath,CompanyImagePath,CompanyObjectiveEng,CompanyObjectiveAra,CompanyHeadLineEng,CompanyHeadLineAra,ID")] CompanyProfile companyProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyProfile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyProfile);
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
