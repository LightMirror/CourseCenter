using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace CourseSite.Common
{
    public static class Email
    {

        public static bool SendEmail(List<string> recevir, string subject, string body, System.Net.Mail.Attachment attachment = null) //abdulrheem 16-01-2018
        {
            try
            {                
                var Senderemail = new MailAddress("lightmirror.eg@gmail.com");
                var Password = "lightmirror@123";
                // var Reciveremail = new MailAddress(recevir);

                var Sub = subject;
                var Body = body;
                // var sender_name = SenderName;
                //var Sender_phone = SenderPhone;


                var stmp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587, // use this port with Enabe SSL
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(Senderemail.Address, Password)
                };

                if (attachment == null)
                {
                    MailMessage message = new MailMessage();
                    message.From = Senderemail;
                    foreach (string re in recevir)
                    {
                        message.To.Add(re);
                    }
                    message.Subject = subject;
                    message.Body = body;
                    stmp.Send(message);
                }
                else
                {
                    MailMessage message = new MailMessage();
                    message.From = Senderemail;
                    foreach (string re in recevir)
                    {
                        message.To.Add(re);
                    }
                    message.Subject = subject;
                    message.Body = body;
                    message.Attachments.Add(attachment);
                    stmp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }       
    }
}