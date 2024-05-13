using BackendAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rehub.Authorization.Extensions;
using ReHub.Db.PostgreSQL;
using ReHub.DbDataModel;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
       private readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(IConfiguration configuration,
            ILogger<AppointmentsController> logger)
        {
            _configuration = configuration;
            _logger = logger;
         }
        /// <summary>
        /// Cancel Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost,Authorize]
        [Route("/rehub/appointments/{appointment_id}/cancel")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("CancelAppointmentAppointmentsAppointmentIdCanselPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult CancelAppointment([FromRoute][Required] int appointment_id)
        {
            if(User == null)
            {
                _logger.LogError("Logged user cannot be null");
                return Unauthorized();
            }
            var role = User.GetRole();
            var id = User.GetUserId();

            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Create Or Join Appointment
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/create")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("CreateOrJoinAppointmentAppointmentsCreatePost")]
        [SwaggerResponse(statusCode: 200, type: typeof(AppointmentPublic), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult CreateOrJoinAppointmentAppointmentsCreatePost([FromBody] AppointmentCreate body)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AppointmentPublic));

            var appointment = new AppointmentPublic {Date=DateTime.Now, Id=1, IsParticipant=true, Status=AppointmentStatusType.ActiveEnum };
            return new JsonResult(appointment);
        }

        /// <summary>
        /// Finish Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/finish")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("FinishAppointmentAppointmentsFinishPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult FinishAppointmentAppointmentsFinishPost([FromQuery][Required()] Object appointmentId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Object));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get Appointment By Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/appointments/{appointment_id}")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("GetAppointmentByIdAppointmentsAppointmentIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult GetAppointmentByIdAppointmentsAppointmentIdGet([FromRoute][Required] Object appointmentId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Object));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            string exampleJson = null;
            exampleJson = "\"\"";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Object>(exampleJson)
            : default(Object);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Join Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/join")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("JoinAppointmentAppointmentsJoinPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(AgoraToken), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult JoinAppointmentAppointmentsJoinPost([FromQuery][Required()] Object appointmentId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(AgoraToken));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            string exampleJson = null;
            exampleJson = "{\r\n  \"uid\" : \"\",\r\n  \"channel_token\" : \"\",\r\n  \"command_token\" : \"\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<AgoraToken>(exampleJson)
            : default(AgoraToken);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Set Listener Pain Rate
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="rateType"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/set-pain-rate")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("SetListenerPainRateAppointmentsSetPainRatePost")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResultMessage), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult SetListenerPainRateAppointmentsSetPainRatePost([FromQuery][Required()] Object rate, [FromQuery][Required()] PainRateType rateType)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ResultMessage));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            string exampleJson = null;
            exampleJson = "{\r\n  \"type\" : \"\",\r\n  \"message\" : \"\",\r\n  \"value\" : \"\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<ResultMessage>(exampleJson)
            : default(ResultMessage);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Start Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/start")]
        //[Authorize(AuthenticationSchemes = BearerAuthenticationHandler.SchemeName)]
        //[ValidateModelState]
        [SwaggerOperation("StartAppointmentAppointmentsStartPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Appointment), description: "Successful Response")]
        [SwaggerResponse(statusCode: 422, type: typeof(HTTPValidationError), description: "Validation Error")]
        public virtual IActionResult StartAppointmentAppointmentsStartPost([FromQuery][Required()] Object appointmentId)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Appointment));

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(HTTPValidationError));
            string exampleJson = null;
            exampleJson = "{\r\n  \"date\" : \"\",\r\n  \"updated_at\" : \"\",\r\n  \"listeners\" : \"\",\r\n  \"speaker\" : {\r\n    \"gender\" : \"\",\r\n    \"avatar_url\" : \"\",\r\n    \"surname\" : \"\",\r\n    \"name\" : \"\",\r\n    \"id\" : \"\",\r\n    \"type\" : \"\",\r\n    \"is_verified\" : \"\",\r\n    \"email\" : \"\"\r\n  },\r\n  \"created_at\" : \"\",\r\n  \"time\" : \"\",\r\n  \"id\" : \"\",\r\n  \"max_listeners\" : \"\",\r\n  \"status\" : \"\"\r\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Appointment>(exampleJson)
            : default(Appointment);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
