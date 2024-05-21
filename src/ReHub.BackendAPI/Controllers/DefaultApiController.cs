using Microsoft.AspNetCore.Mvc;
using ReHub.BackendAPI.Models;
using ReHub.Db.PostgreSQL;

namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    {
        private readonly PostgresDbContext _dbContext;
        private readonly ILogger<DefaultApiController> _logger;
        public DefaultApiController(PostgresDbContext dbContext, ILogger<DefaultApiController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        /// <summary>
        /// Api Health Check
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/healthcheck")]
        //[ValidateModelState]
        public virtual IActionResult ApiHealthCheckHealthcheckGet()
        {
            var checks = new SystemChecks();
            checks.DbCanConnect = _dbContext.Database.CanConnect();
            return Ok(checks);
        }
    }
}
