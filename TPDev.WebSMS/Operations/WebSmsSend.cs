using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPDev.SmsInterface.Interfaces;
using Websms;

namespace TPDev.WebSMS.Operations
{
    public class WebSmsSend : ISendOperations
    {
        public bool Send(long number, string message, int maxMessages = 0, bool isTest = false)
        {
            try
            {
                if (string.IsNullOrEmpty(message)) return false;

                var smsMessage = new TextMessage(number, message);
                uint msgToSend = 1;

                if (maxMessages == 0)
                    msgToSend = CheckMaxMessageCount(message);

                var newClient = new SmsClient("", "", "https://api.websms.com/json");
                var response = newClient.Send(smsMessage, msgToSend, isTest);

                return true;
            }
            catch(Exception ex)
            {
                var exce = ex.Message;
                return false;
            }
        }

        private uint CheckMaxMessageCount(string message)
        {
            var msgLength = 0;
            foreach(char msgChar in message)
            {
                msgLength++;
            }

            var msgToSend = 1;
            if(msgLength > 160)
            {
                msgToSend = msgLength / 160;
            }

            uint msgCount = 1;
            uint.TryParse(msgToSend.ToString(), out msgCount);
            if (msgCount == 0) msgCount = 1;

            return msgCount;
        }
    }
}
