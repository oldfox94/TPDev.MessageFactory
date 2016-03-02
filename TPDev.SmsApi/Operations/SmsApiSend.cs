using System;
using TPDev.SmsInterface.Interfaces;

namespace TPDev.SmsApi.Operations
{
    public class SmsApiSend : ISendOperations
    {
        public bool Send(long number, string message, int maxMessages = 0, bool isTest = false)
        {
            var sendResult = true;
            try
            {
                var smsApi = new SMSApi.Api.SMSFactory(Settings.Client);
                var result = smsApi.ActionSend(number.ToString(), message.ToString()).SetSender("").Execute();



                string[] ids = new string[result.Count];

                for (int i = 0, l = 0; i < result.List.Count; i++)
                {
                    if (!result.List[i].isError())
                    {
                        if (!result.List[i].isFinal())
                        {
                            ids[l] = result.List[i].ID;
                            l++;
                        }
                    }
                }


                result = smsApi.ActionGet().Ids(ids).Execute();
                foreach (var status in result.List)
                {
                    System.Console.WriteLine("ID: " + status.ID + " NUmber: " + status.Number + " Points:" + status.Points + " Status:" + status.Status + " IDx: " + status.IDx);
                    if (status.Status != "DELIVERED")
                        sendResult = false;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return false;
            }

            return sendResult;
        }
    }
}
