using System.Collections.Generic;
using System.Net.Mail;
using WhatsAppApi;
using System.Net;
using Microsoft.Exchange.WebServices.Data;
using System.Configuration;
using System;
using Microsoft.Exchange.WebServices.Autodiscover;
using CourseSite.Models;
using Newtonsoft.Json;
using RestSharp;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Linq;

namespace CourseSite.Common
{
    public  class Email
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
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //public static bool SendEmail(string recevir, string subject, string body, System.Net.Mail.Attachment attachment = null) //hady askalany 13-01-2019
        //{
        //    try
        //    {
        //        var Senderemail = new MailAddress("lightmirror.eg@gmail.com");
        //        var Password = "P@ssw0rdIATLC";

        //        //var Senderemail = new MailAddress("hady_askalany@yahoo.com");
        //        //var Password = "P@ss4raya";

        //        SmtpClient client = new SmtpClient("smtp.gmail.com", 465);
        //        client.EnableSsl = true;
        //        client.Timeout = 3000000; 
        //        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        client.UseDefaultCredentials = true;
        //        client.Credentials = new System.Net.NetworkCredential("lightmirror.eg@gmail.com", Password);
        //        MailMessage message = new MailMessage();
        //        message.To.Add(recevir);
        //        message.From = new MailAddress("lightmirror.eg@gmail.com");
        //        message.Subject = subject;
        //        message.Body = body;
        //        client.ServicePoint.MaxIdleTime = System.Threading.Timeout.Infinite; 
        //        client.Send(message);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static bool SendEmail(string recevir, string subject, string body, System.Net.Mail.Attachment attachment = null) //hady askalany 13-01-2019
        {
            try
            {
                //Application app = new Application();
                //NameSpace ns = app.GetNamespace("mapi");
                //ns.Logon("info@iatlcegypt.com", "P@$$w0rd", false, true); //need to declare outlook user id and password
                //MailItem message = (MailItem)app.CreateItem(OlItemType.olMailItem);
                //message.To = recevir;
                //message.Subject = subject;
                //message.Body = body;
                //message.Send();
                //ns.Logoff();
                //return true;

                ExchangeService myservice = new ExchangeService(ExchangeVersion.Exchange2010_SP1);
                myservice.Credentials = new WebCredentials(ConfigurationSettings.AppSettings.Get("SenderEmailid").ToString(), ConfigurationSettings.AppSettings.Get("Password").ToString());
                try
                {
                    string serviceUrl = ConfigurationSettings.AppSettings.Get("Office365WebserivceURL").ToString();
                    myservice.Url = new Uri(serviceUrl);
                    EmailMessage emailMessage = new EmailMessage(myservice);
                    emailMessage.Subject = subject;
                    emailMessage.Body = new MessageBody(body);
                    emailMessage.ToRecipients.Add(recevir);
                    emailMessage.Send();
                    return true;
                }
                catch (SmtpException exception)
                {
                    string msg = "Mail cannot be sent (SmtpException):";
                    msg += exception.Message;
                    throw new Exception(msg);
                }
                catch (AutodiscoverRemoteException exception)
                {
                    string msg = "Mail cannot be sent(AutodiscoverRemoteException):";
                    msg += exception.Message;
                    throw new Exception(msg);

                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

         public static void SendEmailByMailjet(string recevir, string subject, string body, string body2,string phoneNumber)
        {
            List<Message> Content = new List<Message>();
            Message First = new Message();
            First.From = new From() { Email = "info@iatlcegypt.com", Name = "IATLC" };
            To to = new To() { Email = recevir, Name = recevir };
            First.To = new List<To>();
            First.To.Add(to);
            First.Subject = subject;
            First.TextPart = body;
            Content.Add(First);
            RootObject R = new RootObject();
            R.Messages = Content;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient("https://api.mailjet.com/v3.1/send");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "acd07f59-542b-d51e-c93e-956d2e853810");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("authorization", "Basic Y2MxMWE1YmRkOGNhNDY3ODNkZGFlZjE3N2RjOTBmODI6NTBlZmJmNDVmNmE3MmE2MGE5NjA2NWQzNzFjNmIyZmM=");
            request.AddHeader("content-type", "application/json");
            string t = JsonConvert.SerializeObject(R);
            t = t.Replace("\\r", "").Replace("\\n", "");

            request.AddParameter("application/json", t, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            SendSMS(body2,phoneNumber);
        }

        public static void SendSMS(string body,string pone="+201013445122")
        {
            try
            {
                var accountSid = "AC33dc5e73c9ad28d1033371f6b95b0f89";
                var authToken = "410c2a451662f6f65d600fe2078760ef";
                TwilioClient.Init(accountSid, authToken);
                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(pone));
                messageOptions.From = new PhoneNumber("+16014014846");
                messageOptions.Body = body;

                var message = MessageResource.Create(messageOptions);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}