using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using ReHub.BackendAPI.Models;

namespace ReHub.BackendAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PaymentApiController : ControllerBase
    { 
        /// <summary>
        /// Create Checkout Session
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/payment/create-stripe-checkout-session")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult CreateCheckoutSessionPayment([FromBody]PaymentDataIn body)
        {
            return Ok();
        }

        /// <summary>
        /// Get Lesson Packages
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpGet]
        [Route("/rehub/payment/get-lesson-packages")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult GetLessonPackages()
        {
            return Ok();
        }

        /// <summary>
        /// Validate Payment
        /// </summary>
        /// <param name="body"></param>
        /// <response code="200">Successful Response</response>
        /// <response code="422">Validation Error</response>
        [HttpPost]
        [Route("/rehub/payment/validate-payment")]
        [Authorize]
        //[ValidateModelState]
        public virtual IActionResult ValidatePaymentPayment([FromBody]PaymentDataIn body)
        {
            return Ok();
        }

        /// <summary>
        /// Webhook
        /// </summary>
        /// <response code="200">Successful Response</response>
        [HttpPost]
        [Route("/rehub/payment/stripe-webhook")]
        //[ValidateModelState]
        [SwaggerOperation("WebhookPaymentStripeWebhookPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Object), description: "Successful Response")]
        public virtual IActionResult WebhookPaymentStripe()
        {
            return Ok();
        }
    }
}
