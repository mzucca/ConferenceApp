using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using BackendAPI.Models;
using ReHub.DbDataModel.Services;
using Rehub.Authorization.Extensions;
using ReHub.DbDataModel.Models;

namespace BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserRepository<User> _repository;
        private readonly ILogger<UsersApiController> _logger;

        public UsersApiController(IUserRepository<User> repository,ILogger<UsersApiController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Edit Password
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/edit-password")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult EditPassword([FromBody]UserEditPassword body)
        {
            return Ok();
        }

        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="userId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/by-id")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetById([FromQuery][Required()]int userId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Me
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet,Authorize]
        [Route("/rehub/me")]
        [Authorize]
        //[ValidateModelState]
        [Authorize]
        public virtual IActionResult GetMe()
        {
            _logger.LogDebug("Entering GetMe action");
            if(User == null)
            {
                _logger.LogError("User not found");
                return Unauthorized();
            }
            var id = User.GetUserId();
            if(id<=0)
            {
                _logger.LogError("Invalid token");
                return Unauthorized();
            }
            var user = _repository.GetByID(id);
            if(user==null)
            {
                _logger.LogError($"User '{id}' not found");
                return NotFound(default(UserOut));
            }
            var result = new UserOut(user);
            return Ok(result);
        }

        /// <summary>
        /// Get My Appointments
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/my-appointments")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetMyAppointments()
        {
            return Ok();
        }

        /// <summary>
        /// Get My Notifications
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/my-notifications")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetMyNotifications([FromQuery]int limit, [FromQuery]int offset)
        {
            return Ok();
        }
    }
}
