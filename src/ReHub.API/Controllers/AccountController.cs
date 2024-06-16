using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using ReHub.BackendAPI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Rehub.Authorization.Services;
using ReHub.Utilities.Extensions;
using ReHub.Application.Users;
using ReHub.Infrastructure.Security;
//using Org.BouncyCastle.Asn1.Ocsp;


namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IExternalTokenValidator _externalTokenValidator;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly ILogger<AccountController> _logger;
        private IdentityOptions _options = new IdentityOptions();

        public AccountController(
            IUserService userService,
            IExternalTokenValidator externalTokenValidator,
            IJwtAuthManager jwtAuthManager,
            ILogger<AccountController> logger
        )
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _externalTokenValidator = externalTokenValidator;
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
        [HttpPost("login")]
        [AllowAnonymous]
        //[ValidateModelState]
        public async Task<ActionResult<UserDto>> Login([FromBody] Login request)
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
            return CreateUserObject(userDefinition);

        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            // TODO check with getme
            //var user = await _userManager.Users.Include(p => p.Photos)
            //    .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));

            //return CreateUserObject(user);
            return Ok(); 
        }
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost("externalLogin")]
        [AllowAnonymous]
        //[ValidateModelState]
        public async Task<ActionResult<UserDto>> ExternalLogin([FromBody] OauthToken token)
        {
            if ((token == null) || string.IsNullOrEmpty(token.Token)) return Unauthorized();
            try
            {
                var registerDTO = _externalTokenValidator.GetUserFromToken(token);
                var user = _userService.GetUser(registerDTO.Email);
                if (user == null) return Unauthorized();

                return CreateUserObject(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot validate google token:{ex.Message}");
                _logger.LogError(ex, "Invalid token");
                return Unauthorized();
            }
        }
        [HttpPost("externalRegistration")]
        [AllowAnonymous]
        //[ValidateModelState]
        public async Task<ActionResult<UserDto>> ExternalRegistration([FromBody] OauthToken token)
        {
            if ((token == null) || string.IsNullOrEmpty(token.Token)) return Unauthorized();
            try
            {
                var registerDTO = _externalTokenValidator.GetUserFromToken(token);
                if (registerDTO != null) throw new UserExistsException();
                var user =_userService.RegisterUser(registerDTO);
                return CreateUserObject(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot validate google token:{ex.Message}");
                _logger.LogError(ex, "Invalid token");
                return Unauthorized();
            }
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
        //[SwaggerResponse(statusCode: 200, type: typeof(ResultMessage), description: "Successful Response")]
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
        public virtual ActionResult<LivekitToken> GetLivekitToken(string room)
        {
            // TODO user must be current user
            string user = "marioZ";
            if(string.IsNullOrEmpty(user) || string.IsNullOrEmpty(room))
            {
                _logger.LogError("User and room cannot be null");
                return Ok(null);
            }
            var r = new Random();
            int i = r.Next(1,10);
            var token = TokenUtils.CreateLiveKitToken(user+i, room);
            return Ok(new LivekitToken { Token=token, Url= "wss://marioz-test-geie7rrs.livekit.cloud" });
        }
        private UserDto CreateUserObject(UserDefinition user)
        {
            var claims = new[]
            {
                new Claim(_options.ClaimsIdentity.UserIdClaimType,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(_options.ClaimsIdentity.UserNameClaimType,user.DisplayName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(user.Email, claims, DateTime.Now);
            _logger.LogInformation($"User [{user.Email}] logged in the system.");
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = user.Image,
                Token = jwtResult.AccessToken,
                Email = user.Email
            };
        }

    }
}
