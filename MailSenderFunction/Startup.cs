using MailSenderFunction.Models;
using MailSenderFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(MailSenderFunction.Startup))]
namespace MailSenderFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var services = builder.Services;

            services.AddTransient<SendEmailService>();

            services.Configure<EmailSettings>(e =>
            {
                e.FromEmail = Environment.GetEnvironmentVariable("FromEmail");
                e.FromName = Environment.GetEnvironmentVariable("FromName");
                e.MailPassword = Environment.GetEnvironmentVariable("MailPassword");
                e.SmtpName = Environment.GetEnvironmentVariable("SmtpName");
                e.SmtpPort = int.Parse(Environment.GetEnvironmentVariable("SmtpPort"));
            });
        }
    }
}
