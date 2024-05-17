using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit.Text;
using MimeKit;
using ReHub.Utilities.Configuration;
using MailKit.Net.Smtp;

namespace ReHub.Utilities.Services
{
    public class MailSender : IMailSender
    {
        private readonly MailSenderConfiguration _mailSenderConfiguration= new MailSenderConfiguration();
        private readonly ILogger<MailSenderConfiguration> _logger;

        public MailSender(IConfiguration configuration, ILogger<MailSenderConfiguration> logger)
        {
            var section = configuration.GetSection(MailSenderConfiguration.MailConfigurationSection);
            if(section == null) throw new ArgumentNullException(nameof(section));

            _mailSenderConfiguration = section.Get<MailSenderConfiguration>();
            _logger = logger;
        }

        public bool SendMessage(string message, string to, string subject)
        {
            // create message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_mailSenderConfiguration.FromAddress));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            // TODO add message personalization
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            // send email
            using var smtp = new SmtpClient();
            // TODO check if we need server port
            smtp.Connect(_mailSenderConfiguration.MailServer.ServerAddress, 0, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSenderConfiguration.MailServer.User, _mailSenderConfiguration.MailServer.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
            return true;
        }
    }
}
