using MailKit.Net.Smtp;
using MailSenderFunction.Models;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderFunction.Services
{
    public class SendEmailService
    {
        private readonly EmailSettings _settings;

        public SendEmailService(IOptions<EmailSettings> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }

        public async Task SendEmail(string toEmail, string subject)
        {
            MimeMessage emailMessage = new();

            emailMessage.From.Add(new MailboxAddress(_settings.FromName, _settings.FromEmail));
            emailMessage.To.Add(new MailboxAddress("", toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "Hello"
            };

            using (SmtpClient client = new())
            {
                await client.ConnectAsync(_settings.SmtpName, _settings.SmtpPort, false);
                await client.AuthenticateAsync(_settings.FromEmail, _settings.MailPassword);
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
    }
}
