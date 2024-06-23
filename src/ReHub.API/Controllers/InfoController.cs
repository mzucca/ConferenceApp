using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using ReHub.API.Models;

namespace ReHub.API.Controllers
{
    /// <summary>
    /// This APIs manage the account operations: login, register, change password, and email webhook to verify email provided
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController: ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _actionProvider;
        private readonly ILogger<InfoController> _logger;

        public InfoController(IActionDescriptorCollectionProvider actionProvider, ILogger<InfoController> logger) 
        {
            _actionProvider = actionProvider;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<InfoResult>>  Get()
        {
            var result = new InfoResult();
            var routes = _actionProvider.ActionDescriptors.Items;

            foreach (var route in routes)
            {
                result.RouteInfo.Add(route.DisplayName);
            }
            return Ok(result);
        }
    }
}
