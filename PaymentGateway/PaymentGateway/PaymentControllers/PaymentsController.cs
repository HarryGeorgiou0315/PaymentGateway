using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.PaymentControllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentsLogic _paymentsLogic; 
        public PaymentsController(IPaymentsLogic paymentsLogic)
        {
            _paymentsLogic = paymentsLogic;
        }


        // GET api/payment/06ece360-d46d-487c-9616-aa0551cf0f4e
        [HttpGet("{payment_id}")]
        public IActionResult GetPaymentInfo([FromRoute]Guid id)
        {
            try
            {
                return Ok(_paymentsLogic.RetrievePaymentInfo(id));
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

        // POST api/payment/
        [HttpPost]
        public IActionResult PostPayment([FromBody] PostPaymentRequestBoundary request)
        {
            try
            {
                return Ok(_paymentsLogic.ProcessPayment(request));
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
