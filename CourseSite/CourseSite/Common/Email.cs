﻿using System;
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
                // var Reciveremail = new MailAddress(recevir);

                var Sub = subject;
                var Body = body;
                // var sender_name = SenderName;
                //var Sender_phone = SenderPhone;


                var stmp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25, // use this port with Enabe SSL
                    EnableSsl = true,
                    DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
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
                return false;
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