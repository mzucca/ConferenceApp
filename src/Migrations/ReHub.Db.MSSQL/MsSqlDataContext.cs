using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReHub.DbDataModel;

namespace ReHub.Db.MSSQL
{
    public class MsSqlDataContext : DataContext
    {
        public MsSqlDataContext(IConfiguration configuration, ILogger logger) : base(configuration, logger) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
