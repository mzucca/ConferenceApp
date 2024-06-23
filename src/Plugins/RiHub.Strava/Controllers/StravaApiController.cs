using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using ReHub.Application.Interfaces;
using RiHub.Strava.Authentication;
using RiHub.Strava.Oauth2;
using RiHub.Strava.Services;

namespace RiHub.Strava.Controllers
{
    [ApiController]
    [Route("plugins/[controller]")]
    public class StravaApiController: ControllerBase
    {
        private readonly IAuthenticatorHolder _authenticatorHolder;
        private readonly IUserAccessor _userAccessor;
        private readonly ITokenService _tokenService;
        private readonly StravaClient _client;
        private readonly ILogger<StravaApiController> _logger;
        private readonly IAuthClientFactory _clientFactory;

        public StravaApiController(
            IAuthClientFactory clientFactory,
            IAuthenticatorHolder authenticatorHolder,
            IUserAccessor userAccessor,
            ITokenService tokenService,
            IAuthClientFactory authClientFactory,
            ILogger<StravaApiController> logger) 
        {
            var redirectUrl = $"{Request.Scheme}://{Request.Host}/Home/Callback";
            _logger = logger;
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _authenticatorHolder = authenticatorHolder ?? throw new ArgumentNullException(nameof(authenticatorHolder));
            _userAccessor = userAccessor;
            _tokenService = tokenService;

            _client = authClientFactory.CreateOauth2Client(redirectUrl);

        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetActivities()
        {

            return Ok();
        }
        [HttpGet("callback")]
        public async Task<ActionResult> Callback()
        {
            //var authenticator = await CreateAuthenticator();
            //await authenticator.OnPageLoaded(new Uri(Request.GetDisplayUrl()));
            //return RedirectToAction("Index");
            return Ok();
        }

        private async Task<WebAuthenticator> CreateAuthenticator()
        {
            if (_authenticatorHolder.Authenticator != null)
            {
                return _authenticatorHolder.Authenticator;
            }
            var redirectUrl = $"{Request.Scheme}://{Request.Host}/Home/Callback";
            var client = _clientFactory.CreateOauth2Client(redirectUrl);

            var authenticator = new WebAuthenticator(client, _userAccessor, _tokenService);
            // Set the last AccessToken
            authenticator.AccessToken = "7d03d95baaea48d05a7887dfd65723bcb74372a5";
            await authenticator.RefreshToken();

            _authenticatorHolder.Authenticator = authenticator;
            return authenticator;
        }
    }
}
