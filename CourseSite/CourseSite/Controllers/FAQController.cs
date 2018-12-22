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
    public class FAQController : Controller
    {
        private CenterDBEntities db = new CenterDBEntities();

        // GET: FAQ
        public ActionResult Index()
        {
            return View(db.FAQs.ToList());
        }

        // GET: FAQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQs fAQs = db.FAQs.Find(id);
            if (fAQs == null)
            {
                return HttpNotFound();
            }
            return View(fAQs);
        }

        // GET: FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FAQ_ID,FAQ_QuestionEng,FAQ_QuestionAra,FAQ_AnswerEng,FAQ_AnswerAra,FAQ_Status,FAQ_CreattonUser,FAQ_CreationDate,FAQ_ModifiedUser,FAQ_ModifiedDate")] FAQs fAQs)
        {
            if (ModelState.IsValid)
            {
                fAQs.FAQ_CreationDate = DateTime.Now;
                fAQs.FAQ_ModifiedDate = DateTime.Now;
                db.FAQs.Add(fAQs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fAQs);
        }

        // GET: FAQ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQs fAQs = db.FAQs.Find(id);
            if (fAQs == null)
            {
                return HttpNotFound();
            }
            return View(fAQs);
        }

        // POST: FAQ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FAQ_ID,FAQ_QuestionEng,FAQ_QuestionAra,FAQ_AnswerEng,FAQ_AnswerAra,FAQ_Status,FAQ_CreattonUser,FAQ_CreationDate,FAQ_ModifiedUser,FAQ_ModifiedDate")] FAQs fAQs)
        {
            if (ModelState.IsValid)
            {
                fAQs.FAQ_ModifiedDate = DateTime.Now;
                db.Entry(fAQs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fAQs);
        }

        // GET: FAQ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAQs fAQs = db.FAQs.Find(id);
            if (fAQs == null)
            {
                return HttpNotFound();
            }
            return View(fAQs);
        }

        // POST: FAQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAQs fAQs = db.FAQs.Find(id);
            db.FAQs.Remove(fAQs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AllFAQs()
        {
            using (Models.DAL.CenterDBEntities db = new Models.DAL.CenterDBEntities())
            {
                return PartialView("~/Views/FAQ/_FAQsPV.cshtml", db.FAQs.ToList());
            }
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
