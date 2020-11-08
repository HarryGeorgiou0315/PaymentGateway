using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AquiringBankSimulator.PaymentModels
{
    public class PaymentInfo
    {
        [JsonProperty("paymentId")]
        public Guid PaymentId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cardDetails")]
        public CardDetails CardDetails { get; set; }
        [JsonProperty("billingInfo")]
        public BillingInfo BillingInfo { get; set; }
    }
}
