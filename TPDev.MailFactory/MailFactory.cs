using TPDev.MailFactory.Providers;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;
using MSender = TPDev.MailSender.MailSender;

namespace TPDev.MailFactory
{
    public class MailFactory
    {
        public IProvider Provider { get; set; }
        public ISender Sender { get; set;}

        public MailFactory(MailProviderTypes type, ProviderConnectionData data)
        {
            switch (type)
            {
                case MailProviderTypes.GMail:
                    Provider = new GmailProv();
                    data = Provider.BuildConnectionData(data);
                    Provider.Sender = Sender = new MSender(data);
                    break;
            }

            Settings.Factory = this;
        }

        
    }
}
