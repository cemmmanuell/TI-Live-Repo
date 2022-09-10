namespace mmmSelfservice
{
    using mmmSelfservice.NAVWS;
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;

    public class WSConfig
    {
        public static bool MailFunction(string body, string recepient, string subject)
        {
            bool flag = false;
            try
            {
                string addresses = recepient;
                MailMessage message = new MailMessage();
                message.To.Add(addresses);
                message.Subject = subject;
                message.From = new MailAddress("");
                message.Body = body;
                message.IsBodyHtml = true;
                SmtpClient client2 = new SmtpClient {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("", ""),
                    Port = 0x24b,
                    Host = "smtp.gmail.com",
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                };
                client2.Send(message);
                flag = true;
            }
            catch (Exception exception)
            {
                exception.Data.Clear();
            }
            return flag;
        }

        public static Portals ObjNav
        {
            get
            {
                Portals portals = new Portals();
                try
                {
                    NetworkCredential credential = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                    portals.Credentials = credential;
                    portals.PreAuthenticate = true;
                }
                catch (Exception exception)
                {
                    exception.Data.Clear();
                }
                return portals;
            }
        }
    }
}

