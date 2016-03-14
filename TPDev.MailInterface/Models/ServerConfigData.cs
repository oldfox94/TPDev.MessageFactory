namespace TPDev.MailInterface.Models
{
    public class ServerConfigData
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
