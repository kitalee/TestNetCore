using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.Models
{
    public class MailModel
    {
        public string Title { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Body { get; set; }
    }
}
