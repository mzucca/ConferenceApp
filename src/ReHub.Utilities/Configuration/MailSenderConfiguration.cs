namespace ReHub.Utilities.Configuration
{
    public class MailSenderConfiguration
    {
        public static readonly string MailConfigurationSection = "MailConfiguration";

        /// <summary>
        /// Name of the sender
        /// </summary>
        public string FromName { get; set; }
        /// <summary>
        /// Mail address of the sender
        /// </summary>
        public string FromAddress { get; set; }
        public MailServerConfiguration MailServer{  get; set; }
        /// <summary>
        /// Mail Server Configuration
        /// </summary>
        public class MailServerConfiguration
        {
            /// <summary>
            /// IpAddress of mail server
            /// </summary>
            public string ServerAddress { get; set; }
            /// <summary>
            /// Username for mail server authentication
            /// </summary>
            public string User { get; set; }
            /// <summary>
            /// User password for mail server authentication
            /// </summary>
            public string Password { get; set; }
        }
    }

}
