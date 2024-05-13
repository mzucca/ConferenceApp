using Microsoft.Extensions.Configuration;
using ReHub.DbDataModel.Extensions;

namespace ReHub.Data.Tests
{
    public class ExtensionsTests
    {
        private IConfiguration _configuration;
        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .AddEnvironmentVariables(prefix: "ReHub");

            _configuration = builder.Build();
        }

        [Test]
        public void ReadConfiguration()
        {
            var dbConf = _configuration.GetDbConfiguration();
            Assert.IsNotNull(dbConf);
            Assert.AreEqual(dbConf.EncryptionKey, "my secret configuration key");

            byte[] expected = new byte[] { 246, 38, 38, 179, 164, 194, 198, 226 };
            Assert.IsTrue(expected.SequenceEqual(dbConf.Salt));
        }

    }
}
