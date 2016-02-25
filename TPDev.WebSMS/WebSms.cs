using TPDev.SmsInterface.Models;
using Websms;

namespace TPDev.WebSMS
{
    public class WebSms
    {
        public WebSms(SmsConnectionData conData)
        {
            if (conData == null || string.IsNullOrEmpty(conData.User) || string.IsNullOrEmpty(conData.Password)) return;

            Settings.Client = new SmsClient(conData.User, conData.Password, "https://api.websms.com/json");
        }
    }
}
