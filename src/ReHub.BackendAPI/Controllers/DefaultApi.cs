using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    { 
        /// <summary>
        /// Api Health Check
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/healthcheck")]
        //[ValidateModelState]
        public virtual IActionResult ApiHealthCheckHealthcheckGet()
        {
            return Ok();
        }
    }
}
