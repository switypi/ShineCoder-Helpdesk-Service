﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace ShineCoder_Helpdesk.Core.Models
{
    public  class MessageModel
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public IFormFileCollection Attachments { get; set; }

        public MessageModel(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress("email", x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
