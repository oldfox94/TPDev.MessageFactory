using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;

namespace TPDev.MailSender
{
    public class MailSender : ISender
    {
        public MailSender(ProviderConnectionData conData)
        {
            Settings.ProviderData = conData;
        }

        public bool Send(List<string> toList, string subject, string body, string from = null)
        {
            try
            {
                var result = true;
                foreach(var to in toList)
                {
                    result = Send(to, subject, body, from);
                    if (!result) return result;
                }

                return result;
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                return false;
            }
        }

        public bool Send(string to, string subject, string body, string from = null)
        {
            try
            {
                var mailFrom = string.IsNullOrEmpty(from) ? Settings.ProviderData.MailFrom : from;

                MailMessage mail = new MailMessage(mailFrom, to);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Host = Settings.ProviderData.OutgoingServer.Name;
                client.Port = Settings.ProviderData.OutgoingServer.Port;
                client.EnableSsl = Settings.ProviderData.OutgoingServer.EnableSsl;

                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(Settings.ProviderData.OutgoingServer.Username, Settings.ProviderData.OutgoingServer.Password);

                client.Send(mail);

                return true;
            }
            catch(Exception ex)
            {
                var error = ex.Message;
                return false;
            }
        }
    }
}
