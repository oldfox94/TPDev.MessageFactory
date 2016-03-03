using TPDev.MailFactory.Providers;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;

namespace TPDev.MailFactory
{
    public class MailFactory
    {
        public static IProvider Provider { get; set; }
        public MailFactory(MailProviderTypes type, ProviderConnectionData data)
        {
            switch(type)
            {
                case MailProviderTypes.GMail:
                    Provider = new GmailProv();
                    data = Provider.BuildConnectionData(data);
                    break;
            }

            Settings.Factory = this;
        }

        
    }
}
