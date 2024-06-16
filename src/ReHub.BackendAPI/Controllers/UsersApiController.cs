
namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    //[ApiController]
    //public class UsersApiController : ControllerBase
    //{
    //    private readonly IUserRepository<User> _userRepository;
    //    private readonly INotificationRepository _notificationRepository;
    //    private readonly IStringLocalizer<UsersApiController> _localizer;
    //    private readonly RequestLocalizationOptions _localizationOptions;
    //    private readonly ILogger<UsersApiController> _logger;


    //    public UsersApiController(IUserRepository<User> repository,
    //        INotificationRepository notificationRepository,
    //        IStringLocalizer<UsersApiController> localizer,
    //        IOptions<RequestLocalizationOptions> localizationOptions,
    //        ILogger<UsersApiController> logger)
    //    {
    //        _userRepository = repository;
    //        _notificationRepository = notificationRepository;
    //        _localizer = localizer;
    //        _localizationOptions = localizationOptions.Value;
    //        _logger = logger;

    //        if (_localizationOptions == null)
    //        {
    //            _logger.LogWarning("localization options is null");
    //        }
    //    }

    //    /// <summary>
    //    /// Edit Password
    //    /// </summary>
    //    /// <param name="body"></param>
    //    /// <response code="200">Successful Response</response>
    //    /// <response code="422">Validation Error</response>
    //    [HttpPost]
    //    [Route("/rehub/edit-password")]
    //    [Authorize]
    //    //[ValidateModelState]
    //    public virtual IActionResult EditPassword([FromBody]UserEditPassword body)
    //    {
    //        return Ok();
    //    }

    //    /// <summary>
    //    /// Get By Id
    //    /// </summary>
    //    /// <param name="userId"></param>
    //    /// <response code="200">Successful Response</response>
    //    /// <response code="422">Validation Error</response>
    //    [HttpGet]
    //    [Route("/rehub/by-id")]
    //    [Authorize]
    //    //[ValidateModelState]
    //    public virtual IActionResult GetById([FromQuery][Required()]int userId)
    //    {
    //        return Ok();
    //    }

    //    /// <summary>
    //    /// Get Me
    //    /// </summary>
    //    /// <response code="200">Successful Response</response>
    //    [HttpGet,Authorize]
    //    [Route("/rehub/me")]
    //    [Authorize]
    //    //[ValidateModelState]
    //    [Authorize]
    //    public virtual ActionResult<UserOut> GetMe()
    //    {
    //        _logger.LogDebug("Entering GetMe action");
    //        if(User == null)
    //        {
    //            _logger.LogError("User not found");
    //            return Unauthorized();
    //        }
    //        var id = User.GetUserId();
    //        if(id<=0)
    //        {
    //            _logger.LogError("Invalid token");
    //            return Unauthorized();
    //        }
    //        var user = _userRepository.GetByID(id);
    //        if(user==null)
    //        {
    //            _logger.LogError($"User '{id}' not found");
    //            return NotFound(default(UserOut));
    //        }
    //        var result = new UserOut(user);
    //        return Ok(result);
    //    }

    //    /// <summary>
    //    /// Get My Appointments
    //    /// </summary>
    //    /// <response code="200">Successful Response</response>
    //    [HttpGet]
    //    [Route("/rehub/my-appointments")]
    //    //[Authorize]
    //    //[ValidateModelState]
    //    public virtual ActionResult<List<AppointmentPublic>> GetMyAppointments()
    //    {
    //        var result = new List<AppointmentPublic>();
    //        result.Add(new AppointmentPublic {
    //            Id = 1,
    //            Name = "Session01",
    //            Date = DateTime.UtcNow,
    //            Status = AppointmentStatusType.Active,
    //            District = District.Hip
    //        });
    //        result.Add(new AppointmentPublic {
    //            Id=2,
    //            Name="Session02",
    //            Date = DateTime.UtcNow,
    //            Status = AppointmentStatusType.Active,
    //            District=District.Knee
    //        });
    //        return Ok(result);
    //    }

    //    [HttpPost]
    //    [Route("/rehub/set-culture")]
    //    public ActionResult<ResultMessage> SetCulture(string culture)
    //    {
    //        var supportedCulture = _localizationOptions.SupportedCultures.Where(c=>c.Name.ToLower()==culture.ToLower() || c.TwoLetterISOLanguageName.ToLower() == culture.ToLower()).FirstOrDefault();
    //        if(supportedCulture==null)
    //        {
    //            var errormessage = $"The culture {culture} is not supported. Cannot change default culture";
    //            _logger.LogWarning(errormessage);
    //            return Ok(new ResultMessage { Message = errormessage, Type = ResultMessageType.Error, Value = culture });
    //        }
    //        // Found a valid culture
    //        CultureInfo.CurrentCulture = supportedCulture;

    //        Response.Cookies.Append(
    //            CookieRequestCultureProvider.DefaultCookieName,
    //            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(supportedCulture)),
    //            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) }
    //        );
    //        var template = _localizer["LanguageChangedResult"];
    //        var message = string.Format(template,culture);
    //        return Ok(new ResultMessage { Message=message, Type=ResultMessageType.Success, Value=culture});
    //    }
    //    /// <summary>
    //    /// Get My Notifications
    //    /// </summary>
    //    /// <param name="limit"></param>
    //    /// <param name="offset"></param>
    //    /// <response code="200">Successful Response</response>
    //    /// <response code="422">Validation Error</response>
    //    [HttpGet]
    //    [Route("/rehub/my-notifications")]
    //    [Authorize]
    //    //[ValidateModelState]
    //    public virtual ActionResult<List<NotificationOut>> GetMyNotifications([FromQuery]int limit, [FromQuery]int offset)
    //    {
    //        _logger.LogDebug($"Entering GetMyNotifications with limit={limit} and offset={offset}");
    //        var id = User.GetUserId();
    //        var notifications = _notificationRepository.GetUserNotifications(id,limit, offset);
    //        var result = notifications.GetNotificationOuts();
    //        return Ok(result);
    //    }
    //}
}
