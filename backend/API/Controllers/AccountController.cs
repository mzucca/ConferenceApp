using System.Security.Claims;
using API.DTOs;
using API.Extensions;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Google.Apis.Auth;
using SQLitePCL;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly TokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager,
            TokenService tokenService,
            ILogger<AccountController> logger)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.Email == loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (result)
            {
                return CreateUserObject(user);
            }

            return Unauthorized();
        }
        [AllowAnonymous]
        [HttpGet("externalLogin/{tokenId}")]
        public async Task<ActionResult<UserDto>> ExternalLogin(string tokenId)
        {
            if(string.IsNullOrEmpty(tokenId)) return Unauthorized();
            try
            {
                // Validate the token received by google
                var payload = GoogleJsonWebSignature.ValidateAsync(tokenId,
                    new GoogleJsonWebSignature.ValidationSettings()).Result;

                var user = await _userManager.Users.Include(p => p.Photos)
                    .FirstOrDefaultAsync(x => x.Email == payload.Email);

                if (user == null) return Unauthorized();

                return CreateUserObject(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot validate google token:{ex.Message}");
                _logger.LogError(ex,"Invalid token");
                return Unauthorized();
            }

        }
        [AllowAnonymous]
        [HttpPost("externalRegister")]
        public async Task<ActionResult<UserDto>> ExternalRegister(ExternalRegisterDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.TokenId)) return Unauthorized();
            try
            {
                // Validate the token received by google
                var payload = GoogleJsonWebSignature.ValidateAsync(registerDto.TokenId,
                    new GoogleJsonWebSignature.ValidationSettings()).Result;

                if (await _userManager.Users.AnyAsync(x => x.Email == payload.Email))
                {
                    ModelState.AddModelError("email", "Email taken");
                    return ValidationProblem();
                }

                var user = new AppUser
                {
                    DisplayName = payload.Name,
                    Email = payload.Email,
                    UserName = payload.GivenName
                };
                var result = await _userManager.CreateAsync(user, registerDto.Password);

                if (result.Succeeded)
                {
                    return CreateUserObject(user);
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Cannot validate google token:{ex.Message}");
                _logger.LogError(ex, "Invalid token");
                return Unauthorized();
            }

        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.Username))
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem();
            }

            if (await _userManager.Users.AnyAsync(x => x.Email == registerDto.Email))
            {
                ModelState.AddModelError("email", "Email taken");
                return ValidationProblem();
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Username
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                return CreateUserObject(user);
            }

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.Users.Include(p => p.Photos)
                .FirstOrDefaultAsync(x => x.Email == User.FindFirstValue(ClaimTypes.Email));
                
            return CreateUserObject(user);
        }
        [Authorize]
        [HttpGet]
        [Route("sessiontoken")]
        public async Task<ActionResult<TokenDto>> SessionToken(string room)
        {
            if (User == null)
            {
                return Unauthorized();
            }
            var userName = User.Identity.Name;
            if(string.IsNullOrEmpty(userName)) { return Unauthorized(); }

            var token = TokenExtensions.CreateLiveKitToken(userName, room);

            //return CreateUserObject(user);
            return new OkObjectResult(new TokenDto() { Token = token, Url = "wss://marioz-test-geie7rrs.livekit.cloud" });
        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = user?.Photos?.FirstOrDefault(x => x.IsMain)?.Url,
                Token = _tokenService.CreateToken(user),
                Username = user.UserName
            };
        }
    }
}