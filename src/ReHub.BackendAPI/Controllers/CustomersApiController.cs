using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rehub.Authorization.Extensions;
using ReHub.BackendAPI.Exceptions;
using ReHub.BackendAPI.Models;
using ReHub.DbDataModel.Models;
using ReHub.DbDataModel.Services;
using System.ComponentModel.DataAnnotations;

namespace ReHub.BackendAPI.Controllers
{
    [ApiController]
    public class CustomersApiController : ControllerBase
    {
        private readonly IUserRepository<Doctor> _doctorsRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ILogger<CustomersApiController> _logger;

        public CustomersApiController(IUserRepository<Doctor> repository,
            IClientRepository clientsRepository,
            ILogger<CustomersApiController> logger)
        {
            _clientRepository = clientsRepository;
            _doctorsRepository = repository;
            _logger = logger;
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
        public virtual ActionResult<List<ClientOut>> GetClients([FromQuery] int limit = 100, [FromQuery] int offset = 0)
        {
            //var clients = _repository.GetPaged(offset,limit);

            //return new JsonResult(clients);
            //if (currentUser.Type == UserType.Client)
            //{
            //    throw new ClientAccessDeniedException();
            //}
            //var result = await _clientRepo.GetAll(limit, offset);
            //return Ok(result.ConvertAll(c => ClientOut.FromOrm(c)));
            return Ok(new List<ClientOut>());

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
        public virtual ActionResult<List<ClientWithDetailsOut>> ReadClientsWithDetails([FromQuery] int limit = 100, [FromQuery] int offset = 0)
        {
            var userId = User.GetUserId();
            var currentUser = _clientRepository.GetByID(userId);
            
            if (currentUser == null) throw new UserNotRegisteredException();
            if (currentUser.Type == UserType.Client) throw new ClientAccessDeniedException();

            //var details = _clientRepository.GetDetails(currentUser.Id);
            var result = new List<ClientWithDetailsOut>();
            var customers = _clientRepository.GetPaged(limit, offset);

            foreach (var customer in customers)
            {
                var clientWithDetails = new ClientWithDetailsOut();
            //    var client = Client.FromOrm(clients[i]);
            //    var detail = ClientDetails.FromOrm(details[i]);
            //    clientsWithDetails.Add(ClientWithDetailsOut.ParseObj(new { client, details = detail }));

            }
            return Ok(result);

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
        public virtual ActionResult<ClientDetails> UpdateClientDetails([FromBody] ClientDetails body, [FromRoute][Required] int clientId)
        {
            //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
            //{
            //    throw new ClientAccessDeniedException();
            //}
            //var updatedDetails = await _clientDetailsRepo.Update(clientId, details);
            //return Ok(ClientDetails.FromOrm(updatedDetails));
            return Ok(new ClientDetails());
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
        public ActionResult<ClientOut> ChangeDoctor([FromQuery][Required()] int newDoctorId)
        {
            //if (currentClient.SubType == UserSubType.Anamnesis)
            //{
            //    throw new AnamnesisClientAccessDeniedException();
            //}
            //var newDoctor = await _doctorRepo.GetById(newDoctorId);
            //if (newDoctor == null)
            //{
            //    throw new UserNotFoundException();
            //}
            //var updatedClient = await _clientRepo.Update(currentClient.Id, new { DoctorId = newDoctor.Id });
            //return Ok(updatedClient);
            return Ok(new ClientOut());
        }

        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/client/")]
        //[ValidateModelState
        public virtual ActionResult<ResultMessage> CreateClient([FromBody] ClientCreate body)
        {
            //var existingUser = await _userRepo.GetByEmail(client.Email);
            //if (existingUser != null)
            //{
            //    throw new EmailAlreadyRegisteredException();
            //}
            //var createdClient = await _clientRepo.Create(client);
            //await AssignClientToDoctor(createdClient);
            //SendVerificationEmail(createdClient, backgroundTasks);
            //await new CreateNotificationService(_notificationRepo).WelcomeNewClient(createdClient);
            return Ok(new ResultMessage { Type = ResultMessageType.Success, Message = "Registered" });
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
        public virtual ActionResult<List<PainChartPoint>> GetClientChartData([FromRoute][Required] int clientId, [FromQuery][Required] GroupPainRateDataType groupBy)
        {
            //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
            //{
            //    throw new ClientAccessDeniedException();
            //}
            //var chartData = await _clientRepo.GetPainRatingHistory(clientId, groupBy);
            //return Ok(chartData);
            return Ok(new List<PainChartPoint>());
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
        public virtual ActionResult<ClientOut> GetClientId([FromRoute][Required] int clientId)
        {
            //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
            //{
            //    throw new ClientAccessDeniedException();
            //}
            //var result = await _clientRepo.GetById(clientId);
            //if (result == null)
            //{
            //    throw new UserNotFoundException();
            //}
            //return Ok(ClientOut.FromOrm(result));
            return Ok(new ClientOut());
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
        public virtual ActionResult<ClientDetails> GetClientDetails([FromRoute][Required] int clientId)
        {
            //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
            //{
            //    throw new ClientAccessDeniedException();
            //}
            //var details = await _clientDetailsRepo.Get(clientId);
            //return Ok(ClientDetails.FromOrm(details));
            return Ok(new ClientDetails());
        }



        //[HttpGet,Authorize]
        //public ActionResult<List<ClientOut>> ReadClients(int limit = 100, int offset = 0)
        //{
        //    _logger.LogInformation("Entering ReadClients action");
        //    var currentRole = User.GetRole();
        //    if (currentRole == UserType.Client)
        //    {
        //        _logger.LogError($"ReadClients non permitted to customers");
        //        throw new ClientAccessDeniedException();
        //    }

        //    //var result = await _clientRepo.GetAll(limit, offset);
        //    //return Ok(result.ConvertAll(c => ClientOut.FromOrm(c)));
        //    return Ok(new List<ClientOut>());
        //}

        //[HttpGet("with_details"),Authorize]
        //public ActionResult<List<ClientWithDetailsOut>> ReadClientsWithDetails(int limit = 100, int offset = 0)
        //{
        //    _logger.LogInformation("Entering ReadClientsWithDetails action");
        //    var currentRole = User.GetRole();
        //    if (currentRole != UserType.Client)
        //    {
        //        throw new ClientAccessDeniedException();
        //    }

        //    //var clients = await _clientRepo.GetAll(limit, offset);
        //    //var details = await _clientDetailsRepo.GetAll(limit, offset);

        //    var clientsWithDetails = new List<ClientWithDetailsOut>();
        //    //for (int i = 0; i < clients.Count; i++)
        //    //{
        //    //    var client = Client.FromOrm(clients[i]);
        //    //    var detail = ClientDetails.FromOrm(details[i]);
        //    //    clientsWithDetails.Add(ClientWithDetailsOut.ParseObj(new { client, details = detail }));
        //    //}

        //    return Ok(clientsWithDetails);
        //}

        //[HttpPost,Authorize]
        //public ActionResult<ResultMessage> CreateClient(ClientCreate client) //, [FromServices] BackgroundTasks backgroundTasks)
        //{
        //    var existingUser = _usersRepository.GetByEMail(client.Email);
        //    if (existingUser != null)
        //    {
        //        throw new EmailAlreadyRegisteredException();
        //    }

        //    //var createdClient = await _clientRepo.Create(client);
        //    //await AssignClientToDoctor(createdClient);
        //    //SendVerificationEmail(createdClient, backgroundTasks);
        //    //await new CreateNotificationService(_notificationRepo).WelcomeNewClient(createdClient);

        //    return Ok(new ResultMessage
        //    {
        //        Type = ResultMessageType.Success,
        //        Message = "Registered"
        //    });
        //}

        //[HttpPost("change_doctor")]
        //public ActionResult<ClientOut> ChangeDoctor(int newDoctorId, [FromServices] Client currentClient)
        //{
        //    //if (currentClient.SubType == UserSubType.Anamnesis)
        //    //{
        //    //    throw new AnamnesisClientAccessDeniedException();
        //    //}

        //    //var newDoctor = await _doctorRepo.GetById(newDoctorId);
        //    //if (newDoctor == null)
        //    //{
        //    //    throw new UserNotFoundException();
        //    //}

        //    //var updatedClient = await _clientRepo.Update(currentClient.Id, new { DoctorId = newDoctor.Id });
        //    //return Ok(ClientOut.FromOrm(updatedClient));
        //    return Ok(new ClientOut());
        //}

        //[HttpGet("{clientId}")]
        //public ActionResult<ClientOut> GetClient(int clientId, [FromServices] User currentUser)
        //{
        //    //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
        //    //{
        //    //    throw new ClientAccessDeniedException();
        //    //}

        //    //var result = await _clientRepo.GetById(clientId);
        //    //if (result == null)
        //    //{
        //    //    throw new UserNotFoundException();
        //    //}

        //    //return Ok(ClientOut.FromOrm(result));
        //    return Ok(new ClientOut());
        //}

        //[HttpGet("{clientId}/details")]
        //public ActionResult<ClientDetails> GetClientDetails(int clientId, [FromServices] User currentUser)
        //{
        //    //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
        //    //{
        //    //    throw new ClientAccessDeniedException();
        //    //}

        //    //var details = await _clientDetailsRepo.Get(clientId);
        //    //return Ok(ClientDetails.FromOrm(details));
        //    return Ok(new ClientDetails());
        //}

        //[HttpGet("{clientId}/chart_data")]
        //public ActionResult<List<PainChartPoint>> GetClientChartData(int clientId, GroupPainRateDataType groupBy, [FromServices] User currentUser)
        //{
        //    //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
        //    //{
        //    //    throw new ClientAccessDeniedException();
        //    //}

        //    //var chartData = await _clientRepo.GetPainRatingHistory(clientId, groupBy);
        //    //return Ok(chartData);
        //    return Ok(new List<PainChartPoint>());
        //}

        //[HttpPut("{clientId}/details")]
        //public ActionResult<ClientDetails> UpdateClientDetails(int clientId, ClientDetails details, [FromServices] User currentUser)
        //{
        //    //if (currentUser.Type == UserType.Client && clientId != currentUser.Id)
        //    //{
        //    //    throw new ClientAccessDeniedException();
        //    //}

        //    //var updatedDetails = await _clientDetailsRepo.Update(clientId, details);
        //    //return Ok(ClientDetails.FromOrm(updatedDetails));

        //    return Ok(new ClientDetails());
        //}

    }
}
