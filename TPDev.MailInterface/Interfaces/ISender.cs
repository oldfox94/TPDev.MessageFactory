using System.Collections.Generic;

namespace TPDev.MailInterface.Interfaces
{
    public interface ISender
    {
        bool Send(List<string> toList, string subject, string body, string from = null);
        bool Send(string to, string subject, string body, string from = null);
    }
}
