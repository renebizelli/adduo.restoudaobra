using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace adduo.service.email
{
    public class EmailService : IEmailService
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public EmailService(IConfiguration configuration)
        {
            Email = configuration["Smtp:Email"];
            Name = configuration["Smtp:Name"];
            Password = configuration["Smtp:Password"];
            Host = configuration["Smtp:Host"];
            Port = int.Parse(configuration["Smtp:Port"]); 
        }

        public void Send(EmailDTO dto)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = Email,
                    Password = Password
                };

                client.Credentials = credential;
                client.Host = Host;
                client.Port = Port;
                client.EnableSsl = false;

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(Email, Name);

                    message.To.Add(new MailAddress(dto.To.Email, dto.To.Name));

                    if (dto.Replay != null)
                    {
                        message.ReplyToList.Add(new MailAddress(dto.Replay.Email, dto.Replay.Name));
                    }

                    message.Subject = dto.Subject;
                    message.Body = dto.EmailHtml.Html();
                    message.IsBodyHtml = true;

                    client.Send(message);
                }
            }
        }
    }
}
