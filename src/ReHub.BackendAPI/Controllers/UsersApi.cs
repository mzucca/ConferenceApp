using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        /// Change Doctor
        /// </summary>
        /// <param name="newDoctorId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/client/change_doctor")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ChangeDoctor([FromQuery][Required()]int newDoctorId)
        {
            return Ok();
        }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/client/")]
        //[ValidateModelState]
        [SwaggerOperation("CreateClientClientPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResultMessage), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult CreateClient([FromBody]ClientCreate body)
        {
            return Ok();
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
        /// Get Client Chart Data
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="groupBy"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/client/{client_id}/chart_data")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetClientChartData([FromRoute][Required]int clientId, [FromQuery][Required()]GroupPainRateDataType groupBy)
        {
            return Ok();
        }

        /// <summary>
        /// Get Client
        /// </summary>
        /// <param name="clientId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/client/{client_id}")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetClientId([FromRoute][Required]int clientId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Client Details
        /// </summary>
        /// <param name="clientId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/client/{client_id}/details")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetClientDetails([FromRoute][Required]int clientId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Doctor Clients
        /// </summary>
        /// <param name="doctorId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/doctor/clients")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetDoctorClients([FromQuery][Required()]int doctorId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Doctor
        /// </summary>
        /// <param name="doctorId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/doctor/{id}")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetDoctorId([FromQuery][Required()]int doctorId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Doctor Schedule
        /// </summary>
        /// <param name="doctorId"></param>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/doctor/schedule")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetDoctorSchedule([FromQuery][Required()]int doctorId, [FromBody]BodyGetDoctorScheduleDoctorScheduleGet body)
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

        /// <summary>
        /// Read Clients
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/client/")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetClients([FromQuery]int limit, [FromQuery]int offset)
        {
            var clients = _repository.GetPaged(offset,limit);
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Object));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            
            return new JsonResult(clients);
        }

        /// <summary>
        /// Read Clients With Details
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/client/with_details")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ReadClientsWithDetails([FromQuery]int limit, [FromQuery]int offset)
        {
            return Ok();
        }
        /// <summary>
        /// Read Doctors
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/doctor/")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ReadDoctors([FromQuery]int limit, [FromQuery]int offset)
        {
            return Ok();
        }

        /// <summary>
        /// Update Client Details
        /// </summary>
        /// <param name="body"></param>
        /// <param name="clientId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPut]
        [Route("/rehub/client/{client_id}/details")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult UpdateClientDetails([FromBody]ClientDetails body, [FromRoute][Required]int clientId)
        {
            return Ok();
        }
    }
}
