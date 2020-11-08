using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AquiringBankSimulator.BankSimulatorBoundaries
{
    public class PostPaymentRequestBoundary
    {
        [JsonProperty("cardType")]
        public string CardType { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("address")]

        public string Address { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("nameOnCard")]
        public string NameOnCard { get; set; }
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }
        [JsonProperty("expiryDate")]
        public string ExpiryDate { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cvv")]
        public int CVV { get; set; }
    }
}
