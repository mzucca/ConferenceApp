using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rehub.Authorization.Services;
using ReHub.BackendAPI.Models;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Services;
using ReHub.Utilities.Services;
using System.ComponentModel.DataAnnotations;

namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AppointmentsApiController : ControllerBase
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository<Doctor> _doctorRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IUserService _userService;

        private readonly ILogger<AppointmentsApiController> _logger;


        public AppointmentsApiController(
            IAppointmentRepository appointmentRepository,
            IClientRepository clientRepository,
            IUserRepository<Doctor> doctorRepository,
            INotificationRepository notificationRepository,
            IUserService userService,
            ILogger<AppointmentsApiController> logger)
        {
            _appointmentRepository = appointmentRepository;
            _clientRepository = clientRepository;
            _doctorRepository = doctorRepository;
            _notificationRepository = notificationRepository;
            _userService = userService;
            _logger = logger;
        }
        /// <summary>
        /// Cancel Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost, Authorize]
        [Route("/rehub/appointments/{appointment_id}/cancel")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<ResultMessage>> CancelAppointment(int appointmentId)
        {
            //var currentClient = await _userService.GetCurrentClientAsync();
            //var appointment = await _appointmentRepository.GetAsync(appointmentId);

            //if (appointment == null)
            //    return NotFound(new ResultMessage { Type = ResultMessageType.Error, Message = "Appointment not found" });

            //var appointmentDateTime = appointment.Date.Add(appointment.Time.TimeOfDay);
            //var now = DateTime.Now.AddMinutes(Constants.CANCEL_APPOINTMENT_TIME_COIN_BACK_INDENT);

            //if (!appointment.Listeners.Any(l => l.Id == currentClient.Id))
            //    return Forbid(new ResultMessage { Type = ResultMessageType.Error, Message = "Client access denied" });

            //await _appointmentRepository.RemoveListenerAsync(appointment.Id, currentClient.Id);

            //await _notificationRepository.ClientCancelAppointmentAsync(currentClient, appointment);

            //if (appointmentDateTime > now)
            //{
            //    await _clientRepository.AddBalanceAsync(currentClient.Id, 1);
            //    return Ok(new ResultMessage
            //    {
            //        Type = ResultMessageType.Success,
            //        Message = "Appointment canceled and wallet recharged",
            //        Value = 1
            //    });
            //}

            return Ok(new ResultMessage
            {
                Type = ResultMessageType.Success,
                Message = "Appointment canceled",
                Value = "0"
            });
        }

        /// <summary>
        /// Create Or Join Appointment
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/create")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<AppointmentPublic>> CreateOrJoinAppointment([FromServices] IMailSender mailSender)
        {
            //var client = await _clientRepository.GetByIdAsync(appointment.ClientId);
            //var doctor = await _doctorRepository.GetByIdAsync(appointment.DoctorId);

            //if (client == null)
            //    return NotFound(new ResultMessage { Type = ResultMessageType.Error, Message = "Client not found" });

            //if (doctor == null)
            //    return NotFound(new ResultMessage { Type = ResultMessageType.Error, Message = "Doctor not found" });

            //var dateTime = appointment.Date.Add(appointment.Time.TimeOfDay);
            //var allowedBookingTime = DateTime.Now.AddMinutes(Constants.NEW_APPOINTMENT_TIME_INDENT);

            //if (dateTime < allowedBookingTime)
            //    return BadRequest(new ResultMessage { Type = ResultMessageType.Error, Message = "Time has passed" });

            //if (appointment.Time < Constants.MIN_APPOINTMENT_TIME || appointment.Time > Constants.MAX_APPOINTMENT_TIME)
            //    return BadRequest(new ResultMessage { Type = ResultMessageType.Error, Message = "Bad time" });

            //var currentUser = await _userService.GetCurrentUserAsync();

            //if (currentUser.Id != appointment.DoctorId && currentUser.Id != appointment.ClientId)
            //    return Forbid(new ResultMessage { Type = ResultMessageType.Error, Message = "Appointment creator not participant" });

            //if (!await _appointmentRepository.IsDoctorTimeHasVacanciesAsync(appointment.DoctorId, appointment.Date, appointment.Time))
            //    return BadRequest(new ResultMessage { Type = ResultMessageType.Error, Message = "Doctor busy" });

            //if (client.Balance < 1)
            //    return BadRequest(new ResultMessage { Type = ResultMessageType.Error, Message = "Client balance too low" });

            //var existingAppointment = await _appointmentRepository.GetByTimeAsync(appointment.DoctorId, appointment.Date, appointment.Time);

            //if (existingAppointment == null)
            //{
            //    var maxListeners = client.SubType == UserSubType.Anamnesis ? 1 : 6;
            //    existingAppointment = await _appointmentRepository.CreateAsync(appointment, maxListeners);

            //    await _notificationRepository.DoctorTimeBookedAsync(
            //        appointment,
            //        doctor.Id,
            //        client.Id
            //    );
            //}
            //else
            //{
            //    existingAppointment = await _appointmentRepository.AddListenerAsync(existingAppointment.Id, appointment.ClientId);

            //    await _notificationRepository.DoctorTimeNewParticipantAsync(
            //        appointment,
            //        doctor.Id,
            //        client.Id
            //    );
            //}

            //await _clientRepository.AddBalanceAsync(appointment.ClientId, -1);

            //backgroundTasks.QueueBackgroundWorkItem(async token =>
            //{
            //    await EmailService.SendAppointmentBookedEmailAsync(client, dateTime);
            //});

            return Ok(new AppointmentPublic
            {
                Id = 1, //existingAppointment.Id,
                IsParticipant = true,
                ListenersNum = 3, //existingAppointment.Listeners.Count,
                Speaker = null, //existingAppointment.Speaker,
                Status = AppointmentStatusType.Pending,
                Date = DateTime.UtcNow, //existingAppointment.Date,
                Time = DateTime.UtcNow, //existingAppointment.Time,
                MaxListeners = 8 // existingAppointment.MaxListeners
            });
        }

        /// <summary>
        /// Finish Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/finish")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<Appointment>> FinishAppointment(int appointmentId)
        {
            //var currentDoctor = await _userService.GetCurrentDoctorAsync();
            //var appointment = await _appointmentRepository.ChangeStatusAsync(appointmentId, AppointmentStatusType.Finished);

            //if (appointment == null)
            //    return NotFound(new ResultMessage { Type = ResultMessageType.Error, Message = "Appointment not found" });

            //return Ok(appointment);
            return Ok(new Appointment());
        }

        /// <summary>
        /// Get Appointment By Id
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/appointments/{appointment_id}")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<AppointmentPublic>> GetAppointmentById(int appointmentId)
        {
            //var currentUser = await _userService.GetCurrentUserAsync();
            //var appointment = await _appointmentRepository.GetAsync(appointmentId);

            //if (appointment == null)
            //    return NotFound();

            //if (currentUser.Type == UserType.Client)
            //{
            //    if (!appointment.Listeners.Any(l => l.Id == currentUser.Id))
            //        return Forbid(new ResultMessage { Type = ResultMessageType.Error, Message = "Client access denied" });

            //    return Ok(new AppointmentPublic
            //    {
            //        Id = appointment.Id,
            //        IsParticipant = true,
            //        ListenersNum = appointment.Listeners.Count,
            //        Speaker = appointment.Speaker,
            //        Status = appointment.Status,
            //        Date = appointment.Date,
            //        Time = appointment.Time,
            //        MaxListeners = appointment.MaxListeners
            //    });
            //}

            //return Ok(appointment);
            return Ok(new AppointmentPublic());
        }

        /// <summary>
        /// Join Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/join")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<AgoraToken>> JoinAppointment(int appointmentId)
        {
            //var currentUser = await _userService.GetCurrentUserAsync();
            //var appointment = await _appointmentRepository.GetAsync(appointmentId);

            //if (appointment == null || appointment.Status != AppointmentStatusType.Active)
            //    return BadRequest(new ResultMessage { Type = ResultMessageType.Error, Message = "Appointment not active" });

            //var participantIds = appointment.Listeners.Select(l => l.Id).Concat(new[] { appointment.Speaker.Id });

            //if (!participantIds.Contains(currentUser.Id))
            //    return Forbid(new ResultMessage { Type = ResultMessageType.Error, Message = "User not appointment participant" });

            //return Ok(AgoraTokenGenerator.GenerateToken(currentUser.Id, $"video-conference-{appointmentId}"));
            return Ok(new AgoraToken());
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
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<ResultMessage>> SetListenerPainRate([FromQuery][Required()] int rate, [FromQuery][Required()] PainRateType rateType)
        {
            //var currentClient = await _userService.GetCurrentClientAsync();
            //rate = Math.Max(0, Math.Min(rate, 10));
            //var appointment = await _appointmentRepository.GetCurrentActiveAppointmentAsync(currentClient.Id);

            //if (appointment == null)
            //    return Ok(new ResultMessage { Type = ResultMessageType.Error, Message = "Client has no active appointments" });

            //if (rateType == PainRateType.Before)
            //    await _appointmentRepository.SetListenerPainRateBeforeAsync(rate, appointment.Id, currentClient.Id);
            //else if (rateType == PainRateType.After)
            //    await _appointmentRepository.SetListenerPainRateAfterAsync(rate, appointment.Id, currentClient.Id);

            //return Ok(new ResultMessage { Type = ResultMessageType.Success, Message = "Done", Value = rate });
            return Ok(new ResultMessage { Type = ResultMessageType.Success, Message = "Done", Value = "2" });
        }

        /// <summary>
        /// Start Appointment
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/appointments/start")]
        [Authorize]
        //[ValidateModelState]
        public async Task<ActionResult<Appointment>> StartAppointment(int appointmentId)
        {
            //var currentDoctor = await _userService.GetCurrentDoctorAsync();
            //var appointment = await _appointmentRepository.ChangeStatusAsync(appointmentId, AppointmentStatusType.Active);

            //if (appointment == null)
            //    return NotFound(new ResultMessage { Type = ResultMessageType.Error, Message = "Appointment not found" });

            //await _notificationRepository.AppointmentStartedAsync(appointment, currentDoctor);

            return Ok(new Appointment());
            //return Ok(appointment);
        }
    }
}
