using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ReferrerApiController : ControllerBase
    { 
        /// <summary>
        /// Generate Report
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/referrer/report")]
        //[ValidateModelState]
        public virtual IActionResult GenerateReportReferrer([FromBody]ReferrerReportRequest body)
        {
            return Ok();
        }

        /// <summary>
        /// Get All Referrers
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/referrer/all")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetAllReferrers()
        {
            return Ok();
        }
    }
}
