using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Application.Notifications.Models
{
    public class MessageDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
