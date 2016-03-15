using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;

namespace TPDev.MailFactory.Providers
{
    public class CustomProv : IProvider
    {
        public ProviderConnectionData Data { get; set; }
        public ISender Sender { get; set; }

        public ProviderConnectionData BuildConnectionData(ProviderConnectionData data)
        {
            var conData = new ProviderConnectionData
            {
                MailFrom = string.IsNullOrEmpty(data.MailFrom) ? ""
                                                               : data.MailFrom,
                DefaultUser = data.DefaultUser,
                DefaultPassword = data.DefaultPassword,
                DefaultEnableSsl = data.DefaultEnableSsl,

                IncomingServer = new ServerConfigData
                {
                    Name = data.IncomingServer != null && !string.IsNullOrEmpty(data.IncomingServer.Name) ? data.IncomingServer.Name : "",
                    Port = data.IncomingServer != null && data.IncomingServer.Port > 0 ? data.IncomingServer.Port : 993,
                    Username = data.IncomingServer != null ? data.IncomingServer.Username : data.DefaultUser,
                    Password = data.IncomingServer != null ? data.IncomingServer.Password : data.DefaultPassword,
                    EnableSsl = data.IncomingServer != null ? data.IncomingServer.EnableSsl : data.DefaultEnableSsl,
                },

                OutgoingServer = new ServerConfigData
                {
                    Name = data.OutgoingServer != null && !string.IsNullOrEmpty(data.OutgoingServer.Name) ? data.OutgoingServer.Name : "",
                    Port = data.OutgoingServer != null && data.OutgoingServer.Port > 0 ? data.OutgoingServer.Port : 587,
                    Username = data.OutgoingServer != null ? data.OutgoingServer.Username : data.DefaultUser,
                    Password = data.OutgoingServer != null ? data.OutgoingServer.Password : data.DefaultPassword,
                    EnableSsl = data.OutgoingServer != null ? data.OutgoingServer.EnableSsl : data.DefaultEnableSsl,
                },
            };

            Data = conData;
            return Data;
        }
    }
}
