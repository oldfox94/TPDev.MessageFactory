using TPDev.MailInterface.Models;

namespace TPDev.MailInterface.Interfaces
{
    public interface IProvider
    {
        ProviderConnectionData Data { get; set; }

        ProviderConnectionData BuildConnectionData(ProviderConnectionData data);

        ISender Sender { get; set; }
    }
}
