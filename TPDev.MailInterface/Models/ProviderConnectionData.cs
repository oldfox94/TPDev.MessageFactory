namespace TPDev.MailInterface.Models
{
    public class ProviderConnectionData
    {
        public string MailFrom { get; set; }

        public string DefaultUser { get; set; }
        public string DefaultPassword { get; set; }

        public bool DefaultEnableSsl { get; set; }

        public ServerConfigData IncomingServer { get; set; }
        public ServerConfigData OutgoingServer { get; set; }
    }
}
