using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public class MailViewModel
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        System.Net.Mail.Attachment attachment { get; set; }
    }
}