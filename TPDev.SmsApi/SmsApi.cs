using SMSApi.Api;
using TPDev.SmsInterface.Models;

namespace TPDev.SmsApi
{
    public class SmsApi
    {
        public SmsApi(SmsConnectionData data)
        {
            if (string.IsNullOrEmpty(data.User) || string.IsNullOrEmpty(data.Password)) return;

            Settings.Client = new Client(data.User);
            Settings.Client.SetPasswordHash(data.Password);
        }
    }
}
