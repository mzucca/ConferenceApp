using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class FileApiController : ControllerBase
    { 
        /// <summary>
        /// Download Client Contract
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/file/download/client-contract")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult DownloadClientContract()
        {
            return Ok();
        }
    }
}
