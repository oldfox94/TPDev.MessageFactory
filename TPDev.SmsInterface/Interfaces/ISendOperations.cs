using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDev.SmsInterface.Interfaces
{
    public interface ISendOperations
    {
        bool Send(long number, string message, int maxMessages = 0, bool isTest = false);
    }
}
