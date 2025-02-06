using ECommerce.Business.Abstract;
using ECommerce.Business.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace ECommerce.Business.Concrete
{
    public class EmailService : IEmailService
    {

        private readonly EmailConfig _emailConfig;

        public EmailService(IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

public async Task SendEmailAsync(string email, string subject, string message)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.SmtpUser));
        mimeMessage.To.Add(new MailboxAddress("",email));
        mimeMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = message;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using (var smtpClient = new SmtpClient())
        {
            await smtpClient.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_emailConfig.SmtpUser, _emailConfig.SmtpPass);
            await smtpClient.SendAsync(mimeMessage);
            await smtpClient.DisconnectAsync(true);
        }
    }

}
}
