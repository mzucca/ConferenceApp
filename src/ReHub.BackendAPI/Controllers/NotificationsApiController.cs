using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ReHub.BackendAPI.Models;

namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class NotificationsApiController : ControllerBase
    { 
        /// <summary>
        /// Mark Notifications As Read
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/notifications/read")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ReadNotifications([FromBody]int body)
        {
            return Ok();
        }

        /// <summary>
        /// Publish Notification
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/notifications/publish")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult PublishNotificationsPublish([FromBody]NotificationCreate body)
        {
            return Ok();
        }
    }
}
