namespace TPDev.MailInterface.Models
{
    public class ProviderConnectionData
    {
        public string MailFrom { get; set; }

        public ServerConfigData IncomingServer { get; set; }
        public ServerConfigData OutgoingServer { get; set; }
    }
}
