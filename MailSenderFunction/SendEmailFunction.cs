using System;
using System.Threading.Tasks;
using MailSenderFunction.Models;
using MailSenderFunction.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace MailSenderFunction
{
    public class SendEmailFunction
    {
        private readonly SendEmailService _sendEmailService;

        public SendEmailFunction(SendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        [FunctionName("SendEmailFunction")]
        public async Task Run([ServiceBusTrigger("email-sender-queue", Connection = "ServiceBusConnectionString")]EmailRequestModel requestModel, ILogger log)
        {
            await _sendEmailService.SendEmail(requestModel.ToEmail, requestModel.Subject);
        }
    }
}
