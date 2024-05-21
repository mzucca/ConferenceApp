using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReHub.BackendAPI.Models;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Services;
using System.ComponentModel.DataAnnotations;

namespace ReHub.BackendAPI.Controllers
{
    [ApiController]
    public class DoctorsApiController : ControllerBase
    {
        private readonly IUserRepository<Doctor> _repository;
        private readonly ILogger<UsersApiController> _logger;

        public DoctorsApiController(IUserRepository<Doctor> repository, ILogger<UsersApiController> logger)
        {
            _repository = repository;
            _logger = logger;
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
        public virtual ActionResult<List<DoctorOut>> ReadDoctors([FromQuery] int limit, [FromQuery] int offset)
        {
            return Ok(new List<DoctorOut>());
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
        public virtual ActionResult<List<ClientOut>> GetDoctorClients([FromQuery][Required()] int doctorId)
        {
            return Ok(new List<ClientOut>());
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
        public virtual IActionResult GetDoctorSchedule([FromQuery][Required()] int doctorId, [FromBody] BodyGetDoctorScheduleDoctorScheduleGet body)
        {
            // TODO check the result for this method
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
        public virtual ActionResult<DoctorOut> GetDoctorId([FromQuery][Required()] int doctorId)
        {
            return Ok(new DoctorOut());
        }

    }
}
