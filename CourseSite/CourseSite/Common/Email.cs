using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using WhatsAppApi;

namespace CourseSite.Common
{
    public static class Email
    {

        public static bool SendEmail(List<string> recevir, string subject, string body, System.Net.Mail.Attachment attachment = null) //abdulrheem 16-01-2018
        {
            try
            {

                var Senderemail = new MailAddress("lightmirror.eg@gmail.com");
                var Password = "P@ssw0rdIATLC";

                //var Senderemail = new MailAddress("hady_askalany@yahoo.com");
                //var Password = "P@ss4raya";

                // var Reciveremail = new MailAddress(recevir);

                var Sub = subject;
                var Body = body;
                // var sender_name = SenderName;
                //var Sender_phone = SenderPhone;


                var stmp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 465, // use this port with Enabe SSL
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
                    message.IsBodyHtml = true;
                    stmp.Send(message);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SendEmail(string recevir, string subject, string body, System.Net.Mail.Attachment attachment = null) //hady askalany 13-01-2019
        {
            try
            {
                var Senderemail = new MailAddress("lightmirror.eg@gmail.com");
                var Password = "P@ssw0rdIATLC";

                //var Senderemail = new MailAddress("hady_askalany@yahoo.com");
                //var Password = "P@ss4raya";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
                client.EnableSsl = true;
                client.Timeout = 3000000; 
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential("lightmirror.eg@gmail.com", Password);
                MailMessage message = new MailMessage();
                message.To.Add(recevir);
                message.From = new MailAddress("lightmirror.eg@gmail.com");
                message.Subject = subject;
                message.Body = body;
                client.ServicePoint.MaxIdleTime = System.Threading.Timeout.Infinite; 
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SendWhatsapp(string to,string msg)
        {
            //Send ( button_click )
            string from = "201013445122";
            bool sent = false;

            WhatsApp wa = new WhatsApp(from, "%be%15%cb%c4d%14%0e%b6%de%94%96%0b%da%8c%d6%d9%ffpf%a1", "IATLC", true, true);

            wa.OnConnectSuccess += () =>
            {
                wa.OnLoginSuccess += (phoneNumber, data) =>
                {
                    wa.SendMessage(to, msg);
                    sent = true;
                };

                wa.OnLoginFailed += (data) =>
                {
                    sent = false;
                };

                wa.Login();
            };

            wa.OnConnectFailed += (ex) =>
            {
                sent = false;
            };

            wa.Connect();
            return sent;
        }
    }
}