using TPDev.MailFactory.Providers;
using TPDev.MailInterface.Interfaces;
using TPDev.MailInterface.Models;
using MSender = TPDev.MailSender.MailSender;

namespace TPDev.MailFactory
{
    public class MailFactory
    {
        public static IProvider Provider { get; set; }
        private static ISender m_Sender { get; set;}

        public MailFactory(MailProviderTypes type, ProviderConnectionData data)
        {
            m_Sender = new MSender();

            switch (type)
            {
                case MailProviderTypes.GMail:
                    Provider = new GmailProv();
                    data = Provider.BuildConnectionData(data);
                    Provider.Sender = m_Sender;
                    break;
            }

            Settings.Factory = this;
        }

        
    }
}
