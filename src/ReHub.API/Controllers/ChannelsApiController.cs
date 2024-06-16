using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using ReHub.BackendAPI.Models;

namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ChannelsApiController : ControllerBase
    { 
        /// <summary>
        /// Add Conference Action
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/channels/add-action")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult AddConference([FromBody]ConferenceActionIn body)
        { 
            return Ok();
        }

        /// <summary>
        /// Close Conference
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpDelete]
        [Route("/rehub/channels/")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult CloseConferenceChannels([FromQuery][Required()]int conferenceId)
        {
            return Ok();
        }

        /// <summary>
        /// Create Conference
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/channels/")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult CreateConference([FromBody]ConferenceIn body)
        { 
            return Ok();
        }

        /// <summary>
        /// Get Channel Token
        /// </summary>
        /// <param name="channelName"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/channels/get-token")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetChannelToken([FromQuery][Required()]string channelName)
        {
            return Ok();
        }

        /// <summary>
        /// Get Conference Actions
        /// </summary>
        /// <param name="conferenceId"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/channels/actions")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetConferenceActions([FromQuery][Required()]int conferenceId)
        {
            return Ok();
        }

        /// <summary>
        /// Get Conference
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="404">The channel was not found</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/channels/by-id")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetConferenceChannelsById([FromQuery][Required()]int id)
        {
            return Ok();
        }

        /// <summary>
        /// Read Conferences
        /// </summary>
        /// <param name="onlyActive"></param>
        /// <param name="limit"></param>
        /// <param name="skip"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpGet]
        [Route("/rehub/channels/")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ReadConferencesChannels([FromQuery]bool onlyActive, [FromQuery]int limit, [FromQuery]int skip)
        {
            return Ok();
        }
    }
}
