using CourseSite.Models;
using log4net;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;
using CourseSite.Controllers;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace CourseSite.Common
{
    public class General
    {
        #region Logging system
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Logs error the an XML file using log4net
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="fileName">File name that exception occurred in</param>
        /// <owner>MBadry</owner>
        public static void LogError(Exception ex, string fileName)
        {            
            Log.Error(ex.ToString() + " in " + fileName);            
            string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~");
            FilePath += "\\log.xml";
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FilePath);
            List<string> ErrorRecivers = new List<string> { "eng.abdulrheem@gmail.com" };
            Email.SendEmail(ErrorRecivers, "Exception in CourseSite", "Please check attahced file to finde Log Exception", attachment);
        }
        /// <summary>
        /// Logs error the an XML file using log4net
        /// </summary>
        /// <param name="message"></param>
        /// <owner>MBadry</owner>
        public static void LogError(string message)
        {
            Log.Error(message);
            string FilePath = System.Web.Hosting.HostingEnvironment.MapPath("~");
            FilePath += "\\log.xml";
            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(FilePath);
            List<string> ErrorRecivers = new List<string> { "eng.abdulrheem@gmail.com" };
            Email.SendEmail(ErrorRecivers, "Exception in CourseSite", "Please check attahced file to finde Log Exception", attachment);
        }

        #endregion
        public static MainViewModel BuildMainView()
        {
            MainViewModel MVM = new MainViewModel();
            MVM.Faqs = FAQsRoutines.GetTopFAQsForMAin();
            MVM.Courses = CourseRoutine.GetTopCoursesForMAin();
            MVM.Gallary = GalleryController.GetActiveGallary();
            MVM.Instarctors = InstractorsRoutines.GetAll();
            return MVM;
        }
    }
    public class MyXmlLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {
            writer.WriteStartElement("LogEntry");
            writer.WriteStartElement("Time");
            writer.WriteString(loggingEvent.TimeStamp.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("Message");
            writer.WriteString(loggingEvent.RenderedMessage);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}