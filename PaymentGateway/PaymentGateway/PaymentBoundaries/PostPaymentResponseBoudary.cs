using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentBoundaries
{
    public class PostPaymentResponseBoudary
    {
        [JsonProperty("payment_id")]
        public Guid PaymentId { get; set; }
    }
}
