using CodeHub.DTO;
using CodeHub.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace CodeHub.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(SendEmailDto dto)
        {
            var fromAddress = AppSettings.GetSettingAsString("EmailCredentials:Email");
            var fromPassword = AppSettings.GetSettingAsString("EmailCredentials:Password");
            var host = AppSettings.GetSettingAsString("EmailCredentials:SmtpServer");
            var port = Int32.Parse(_config["EmailCredentials:Port"]);

            var toAddress = new MailAddress(dto.ToEmail);
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromAddress);
                mail.To.Add(toAddress);
                mail.Subject = dto.Subject;
                mail.Body = dto.Body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = host;
                    smtp.Port = port;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                }
            }
        }
    }
}
