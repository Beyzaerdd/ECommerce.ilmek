using ECommerce.Business.Abstract;
using ECommerce.Business.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            using (var smtpClient = new SmtpClient(_emailConfig.SmtpServer, _emailConfig.SmtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_emailConfig.SmtpUser, _emailConfig.SmtpPass);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailConfig.SmtpUser),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}
