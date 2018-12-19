using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseSite.Models
{
    public class MailViewModel
    {
        string FirstName { get; set; }
        string SecondName { get; set; }
        string subject { get; set; }
        string body { get; set; }
        System.Net.Mail.Attachment attachment { get; set; }
    }
}