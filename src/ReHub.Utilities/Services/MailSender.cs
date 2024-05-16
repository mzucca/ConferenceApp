using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReHub.Utilities.Configuration;

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
    }
}
