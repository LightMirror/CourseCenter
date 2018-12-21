using CourseSite.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CourseSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MainViewModel MVM = new MainViewModel();
            MVM = CourseSite.Common.General.BuildMainView();
            return View("Main", MVM);
        }

        [Authorize]
        public ActionResult MainAdmin()
        {
            return View("MainAdmin");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult ChangeLang()
        {
            try
            {
                string lang = "en";
                lang = Common.UImanger.CurrentLang == "en" ? "ar-EG" : "en";
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = lang;
                Response.Cookies.Add(cookie);
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
            catch (Exception ex)
            {
                Common.General.LogError(ex, "HomeController.cs");
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }
        [HttpPost]
        public ActionResult SendEmailMessage([Bind(Include = "name,email,subject,message")]MailViewModel EVM)
        {

            string NewLine = "\n";
            string RealBody = "Name: " +EVM.Name+ NewLine;
            RealBody += "E-mail: " + EVM.email + NewLine;
            RealBody += "Message:" + NewLine + EVM.message;
            List<string> Recivers = new List<string>();Recivers.Add("eng.abdulrheem@gmail.com");
            CourseSite.Common.Email.SendEmail(Recivers, EVM.subject, RealBody);
            return View("Main");
        }
    }
}