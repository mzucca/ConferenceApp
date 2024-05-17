using BackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReHub.DbDataModel.Models;
using System.Net.WebSockets;
using System.Text;

namespace ReHub.BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConferenceApiController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ConferenceApiController> _logger;

        public ConferenceApiController(IServiceProvider serviceProvider, ILogger<ConferenceApiController> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conference>>> ReadConferences(
            [FromQuery] bool onlyActive = true,
            [FromQuery] int limit = 100,
            [FromQuery] int skip = 0)
        {
            //var conferences = _serviceProvider.GetRequiredService<ConfRepo>();
            //var currentUser = _serviceProvider.GetRequiredService<User>();
            //return await conferences.GetAll(onlyActive, limit, skip);
            return Ok(new List<Conference>());
        }

        [HttpGet("by-id")]
        public async Task<ActionResult<Conference>> GetConference(
            [FromQuery] int id)
        {
            //var conferences = _serviceProvider.GetRequiredService<ConfRepo>();
            //var currentUser = _serviceProvider.GetRequiredService<User>();
            //var conference = await conferences.GetById(id);
            //if (conference == null)
            //{
            //    return NotFound(new ResultMessage { Message = "Channel not found" });
            //}
            //return conference;

            return Ok(new Conference());
        }

        [HttpPost]
        public async Task<ActionResult<Conference>> CreateConference(
            [FromBody] ConferenceIn conference)
        {
            //var conferences = _serviceProvider.GetRequiredService<ConfRepo>();
            //var actions = _serviceProvider.GetRequiredService<ConfActionRepo>();
            //var notifications = _serviceProvider.GetRequiredService<NotificationRepo>();
            //var currentDoctor = _serviceProvider.GetRequiredService<User>();

            //var createdConference = await conferences.Create(conference, currentDoctor.Id);
            //await actions.Create(new ConferenceActionIn
            //{
            //    Action = "open",
            //    ConferenceId = createdConference.Id,
            //    ActorId = currentDoctor.Id
            //});

            // TODO handle non-unique conf name case (only for active confs)
            // var n = new NotificationCreate
            // {
            //     Message = "Your call <b>started!</b><div><br><div>Click here to join [link will be here]</div></div>",
            //     RecipientTypes = new List<UserType> { UserType.Client },
            //     RecipientIds = conference.ParticipantIds
            // };
            // await notifications.Create(currentDoctor.Id, n);

            // return createdConference;
            return Ok(new Conference());
        }

        [HttpGet("get-token")]
        public async Task<ActionResult<AgoraToken>> GetChannelToken(
            [FromQuery] string channelName)
        {
            //var currentUser = _serviceProvider.GetRequiredService<User>();
            //var uid = currentUser.Id;
            //var currentTimeStamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            //var privilegeExpiredTs = currentTimeStamp + Config.AGORA_CHANNEL_TOKEN_EXPIRE_MINUTES * 60;
            //var role = 1;

            //var channelToken = RtcTokenBuilder.BuildTokenWithUid(
            //    Config.AGORA_APP_ID,
            //    Config.AGORA_APP_CERTIFICATE,
            //    channelName,
            //    uid,
            //    role,
            //    privilegeExpiredTs
            //);

            //var commandToken = RtmTokenBuilder.BuildToken(
            //    Config.AGORA_APP_ID,
            //    Config.AGORA_APP_CERTIFICATE,
            //    uid.ToString(),
            //    role,
            //    privilegeExpiredTs
            //);

            //return new AgoraToken
            //{
            //    ChannelToken = channelToken,
            //    CommandToken = commandToken,
            //    Uid = uid
            //};
            return Ok(new AgoraToken());
        }

        [HttpDelete]
        public async Task<ActionResult<ResultMessage>> CloseConference(
            [FromQuery] int conferenceId)
        {
            //var conferences = _serviceProvider.GetRequiredService<ConfRepo>();
            //var actions = _serviceProvider.GetRequiredService<ConfActionRepo>();
            //var currentDoctor = _serviceProvider.GetRequiredService<User>();

            //await conferences.Close(conferenceId);
            //await actions.Create(new ConferenceActionIn
            //{
            //    Action = "close",
            //    ConferenceId = conferenceId,
            //    ActorId = currentDoctor.Id
            //});

            return new ResultMessage
            {
                Message = "Channel closed",
                Type = ResultMessageType.Success
            };
        }

        [HttpGet("actions")]
        public async Task<ActionResult<List<ConferenceAction>>> GetConferenceActions(
            [FromQuery] int conferenceId)
        {
            //var actions = _serviceProvider.GetRequiredService<ConfActionRepo>();
            //var currentUser = _serviceProvider.GetRequiredService<User>();
            //return await actions.GetAll(conferenceId);
            return Ok(new List<ConferenceAction>());
        }

        [HttpPost("add-action")]
        public async Task<ActionResult<ConferenceAction>> AddConferenceAction(
            [FromBody] ConferenceActionIn action)
        {
            //var actions = _serviceProvider.GetRequiredService<ConfActionRepo>();
            //var currentUser = _serviceProvider.GetRequiredService<User>();
            //return await actions.Create(action);
            return Ok(new ConferenceAction());
        }

        //[Route("ws")]
        //public async Task ConferenceWebSocketEndpoint()
        //{
        //    //var wsManager = _serviceProvider.GetRequiredService<WSManager>();
        //    //var context = HttpContext;
        //    //var webSocket = await context.WebSockets.AcceptWebSocketAsync();
        //    //await wsManager.Connect(webSocket);
        //    //Console.WriteLine($">>>>>>>>> WS {webSocket} connected");

        //    //try
        //    //{
        //    //    var buffer = new byte[1024 * 4];
        //    //    while (webSocket.State == WebSocketState.Open)
        //    //    {
        //    //        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        //    //        if (result.MessageType == WebSocketMessageType.Text)
        //    //        {
        //    //            var data = Encoding.UTF8.GetString(buffer, 0, result.Count);
        //    //            Console.WriteLine($">>>>>>>>> Data received through WS: {data}");
        //    //            await wsManager.Broadcast($"Hello from WebSocket. You wrote: {data}");
        //    //        }
        //    //    }
        //    //}
        //    //catch (WebSocketException)
        //    //{
        //    //    wsManager.Disconnect(webSocket);
        //    //    Console.WriteLine($">>>>>>>>> WS {webSocket} disconnected");
        //    //}
        //}
    }
}
