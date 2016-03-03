using TPDev.MailInterface.Models;

namespace TPDev.MailInterface.Interfaces
{
    public interface IProvider
    {
        ProviderConnectionData BuildConnectionData(ProviderConnectionData data);
    }
}
