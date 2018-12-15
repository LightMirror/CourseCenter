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

            return View("Main");
        }
        //public ActionResult Main()
        //{
        //    return View();
        //}

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
    }
}