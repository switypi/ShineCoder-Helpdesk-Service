using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShineCoder_Helpdesk.Core.Models;

namespace ShineCoder_Helpdesk.Core
{
    public interface IEmailSender
    {
        void SendEmail(MessageModel message);
        Task SendEmailAsync(MessageModel message);
    }
}
