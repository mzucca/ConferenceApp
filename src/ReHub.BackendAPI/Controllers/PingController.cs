using Microsoft.AspNetCore.Mvc;
using ReHub.Db.PostgreSQL;

namespace ReHub.BackendAPI.Controllers
{
    [ApiController]
    public class PingController : Controller
    {
        private readonly PostgresDbContext _dbContext;
        private readonly ILogger<PingController> _logger;

        public PingController(PostgresDbContext dbContext, ILogger<PingController> logger) 
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        // TODO add db and other checks
        /// <summary>
        /// Check if the server is online
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/rehub/ping")]
        public IActionResult IsAlive()
        {
            var checks = new Checks();
            checks.DbCanConnect = _dbContext.Database.CanConnect();
            return Ok(checks);
        }
    }
    public class Checks
    {
        public bool DbCanConnect { get; set; }
    }
}
