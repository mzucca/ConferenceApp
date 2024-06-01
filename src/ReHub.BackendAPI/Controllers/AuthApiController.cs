using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using ReHub.BackendAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Rehub.Authorization.Services;
using ReHub.Utilities.Extensions;


namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<AuthApiController> _logger;
        private IdentityOptions _options = new IdentityOptions();

        public AuthApiController(
            IUserService userService,
            IJwtAuthManager jwtAuthManager,
            ILogger<AuthApiController> logger
        )
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _jwtAuthManager = jwtAuthManager ?? throw new ArgumentNullException(nameof(jwtAuthManager));
            _logger=logger ?? throw new ArgumentNullException(nameof( logger));
        }

        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="token"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/confirm-email/{token}")]
        //[ValidateModelState]
        public virtual IActionResult ConfirmEmailConfirmEmailTokenPost([FromRoute][Required] string token)
        {
            return Ok();
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/login")]
        [AllowAnonymous]
        //[ValidateModelState]
        public virtual IActionResult Login([FromBody] Login request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Login attempted with invalid credentials");
                return BadRequest();
            }
            var userDefinition = _userService.GetUserCredentials(request.Email, request.Password);
            if (userDefinition == null)
            {
                _logger.LogError($"Login '{request.Email}' attempted with invalid credentials");
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(_options.ClaimsIdentity.UserIdClaimType,userDefinition.Id.ToString()),
                new Claim(ClaimTypes.Name,request.Email),
                new Claim(_options.ClaimsIdentity.UserNameClaimType,userDefinition.Name),
                new Claim(ClaimTypes.Role, userDefinition.Role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(request.Email, claims, DateTime.Now);
            _logger.LogInformation($"User [{request.Email}] logged in the system.");
            return Ok(new LoginResult
            {
                UserName = request.Email,
                Role = "admin", // TODO
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        /// <summary>
        /// Resend Email Confirmation
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpPost]
        [Route("/rehub/resend-confirmation")]
        [Authorize]
        //[ValidateModelState]
        [SwaggerOperation("ResendEmailConfirmationResendConfirmationPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(ResultMessage), description: "Successful Response")]
        public virtual IActionResult ResendEmailConfirmationResendConfirmationPost()
        {
            return Ok();
        }

        /// <summary>
        /// Verify Token
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/verify-token")]
        [Authorize]
        //[ValidateModelState]
         public virtual ActionResult<TokenVerify> VerifyToken([FromBody] Token body)
        {
            if (User == null)
                return Ok(new TokenVerify { IsValid = false });

            return Ok(new TokenVerify { IsValid=true});
        }
        /// <summary>
        /// Verify Token
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/get_livekit-token")]
        public virtual ActionResult<LivekitToken> GetLivekitToken(string user, string room)
        {
            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(room))
            {
                _logger.LogError("User and room cannot be null");
                return Ok(null);
            }
            var token = TokenUtils.CreateLiveKitToken(user, room);
            return Ok(new LivekitToken { Token=token, Url= "wss://marioz-test-geie7rrs.livekit.cloud" });
        }


    }
}
