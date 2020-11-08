using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentGateways;
using PaymentGateway.PaymentInterfaces;

namespace PaymentGateway.PaymentControllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentsLogic _paymentsLogic; 
        public PaymentsController(IPaymentsLogic paymentsLogic)
        {
            _paymentsLogic = paymentsLogic;
        }


        // GET api/payments/06ece360-d46d-487c-9616-aa0551cf0f4e
        [HttpGet("{paymentId}")]
        public IActionResult GetPaymentInfo([FromRoute]Guid paymentId)
        {
            try
            {
                return Ok(_paymentsLogic.RetrievePaymentInfo(paymentId));
            }
            catch (PaymentInformationNotFoundException)
            {
                return NotFound($"Payment information for id {paymentId} not found.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(400, $"The request to retrieve payment information has failed with - " +
                    $"           {ex.Message} - {ex.InnerException}");
            }
            catch (Exception ex)
            { //catch any other exceptions that may have occured during execution
                return StatusCode(500, $"An error has occured while executing the request - " +
                                                $"{ex.Message} - {ex.InnerException}");
            }
        }

        // POST api/payments/
        [HttpPost]
        public IActionResult PostPayment([FromBody] PostPaymentRequestBoundary request)
        {
            try
            {
                var result = _paymentsLogic.ProcessPayment(request);
                return CreatedAtAction(nameof(GetPaymentInfo), new { paymentId = result.PaymentId }, result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(400, $"The request to process payment information has failed with - " +
                    $"           {ex.Message} - {ex.InnerException}");
            }
            catch (Exception ex)
            { //catch any other exceptions that may have occured during execution
                return StatusCode(500, $"An error has occured while executing the request - " +
                                                $"{ex.Message} - {ex.InnerException}");
            }
        }
    }
}
