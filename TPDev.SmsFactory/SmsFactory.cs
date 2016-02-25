using TPDev.SmsInterface.Interfaces;
using TPDev.SmsInterface.Models;
using TPDev.WebSMS;
using TPDev.WebSMS.Operations;

namespace TPDev.SmsFactory
{
    public class SmsFactory
    {
        public ISendOperations Send { get; set; }

        public SmsFactory(SmsType type, SmsConnectionData data)
        {
            SmsFactorySettings.Type = type;
            switch(type)
            {
                case SmsType.WebSMS:
                    new WebSms(data);
                    break;
            }

            SmsFactorySettings.Factory = this;

            Send = GetSendService();
        }

        public ISendOperations GetSendService()
        {
            switch(SmsFactorySettings.Type)
            {
                case SmsType.WebSMS:
                    return new WebSmsSend();
            }

            return null;
        }
    }
}
