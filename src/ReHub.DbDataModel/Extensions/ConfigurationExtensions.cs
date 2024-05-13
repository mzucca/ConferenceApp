using Microsoft.Extensions.Configuration;
using ReHub.DbDataModel.Configuration;

namespace ReHub.DbDataModel.Extensions
{
    public static class ConfigurationExtensions
    {
        public static DbConfiguration GetDbConfiguration(this IConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var conf = configuration.GetSection(DbConfiguration.SectionName);
            if (conf == null) throw new ArgumentException($"Cannot find {DbConfiguration.SectionName} in configuration. Please check your application settings.");

            var dbSettings = conf.Get<DbConfiguration>();
            var connectionString = configuration[":DbConfiguration:ConnectionString"];
            if (!string.IsNullOrEmpty(connectionString))
            {
                dbSettings.ConnectionString = connectionString;
            }


            return dbSettings;
        }
    }
}
