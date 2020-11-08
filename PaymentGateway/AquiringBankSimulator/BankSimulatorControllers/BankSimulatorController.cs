using System;
using AquiringBankSimulator.BankSimulatorBoundaries;
using Microsoft.AspNetCore.Mvc;

namespace AquiringBankSimulator.BankSimulatorControllers
{
    [Route("api/banksimulator")]
    [ApiController]
    public class BankSimulatorController : ControllerBase
    {
        [HttpGet("{payment_id}")]
        public IActionResult GetPaymentInfo([FromRoute] Guid payment_id)
        {
            switch (payment_id.ToString())
            {
                case "cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3":
                    return Ok(FakeBoundaryResponses.GetPaymentInfoFakeResponse.PaymentInfoFakeResponse1());
                case "92752c4b-3ab4-4069-a2eb-613efda81a66":
                    return Ok(FakeBoundaryResponses.GetPaymentInfoFakeResponse.PaymentInfoFakeResponse2());
                default:
                    return StatusCode(404, $"The request to retrieve payment information for this id {payment_id} not found.");
            }

        }

        [HttpPost]
        public IActionResult PostPayment([FromBody] PostPaymentRequestBoundary request)
        {
            if (request.NameOnCard == "test")
            {
                return StatusCode(400, $"The request to process payment failed.");
            }
            return StatusCode(201, Guid.NewGuid());
        }
    }
}
