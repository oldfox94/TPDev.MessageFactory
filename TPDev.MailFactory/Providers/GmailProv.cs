using System;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;

namespace TPDev.MailFactory.Providers
{
    public class GmailProv : IProvider
    {
        public ProviderConnectionData Data { get; set; }
        public ISender Sender { get; set; }

        public ProviderConnectionData BuildConnectionData(ProviderConnectionData data)
        {
            var conData = new ProviderConnectionData
            {
                MailFrom = string.IsNullOrEmpty(data.MailFrom) ? "noreplay@gmail.com" : data.MailFrom,

                IncomingServer = new ServerConfigData
                {
                    Name = data.IncomingServer != null && !string.IsNullOrEmpty(data.IncomingServer.Name) ? data.IncomingServer.Name : "imap.gmail.com",
                    Port = data.IncomingServer != null && data.IncomingServer.Port > 0 ? data.IncomingServer.Port : 993,
                    Username = data.IncomingServer != null ? data.IncomingServer.Username : string.Empty,
                    Password = data.IncomingServer != null ? data.IncomingServer.Password : string.Empty,
                },

                OutgoingServer = new ServerConfigData
                {
                    Name = data.OutgoingServer != null && !string.IsNullOrEmpty(data.OutgoingServer.Name) ? data.OutgoingServer.Name : "smtp.gmail.com",
                    Port = data.OutgoingServer != null && data.OutgoingServer.Port > 0 ? data.OutgoingServer.Port : 587,
                    Username = data.OutgoingServer != null ? data.OutgoingServer.Username : string.Empty,
                    Password = data.OutgoingServer != null ? data.OutgoingServer.Password : string.Empty,
                },
            };

            Data = conData;
            return Data;
        }
    }
}
