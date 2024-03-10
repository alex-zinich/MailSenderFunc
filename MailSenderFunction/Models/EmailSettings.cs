using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderFunction.Models
{
    public class EmailSettings
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string MailPassword { get; set; }
        public string SmtpName { get; set; }
        public int SmtpPort { get; set; }
    }
}
