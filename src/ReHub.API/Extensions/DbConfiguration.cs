using ReHub.Utilities.Encryption;

namespace ReHub.BackendAPI.Extensions
{
    public class DbConfiguration
    {
        public const string SectionName = nameof(DbConfiguration);
        public string ConnectionString { get; set; }
        public string EncryptionKey { get; set; }
        public EncryptionAlgorithm EncryptionAlgorithm { get; set; }
    }
}
