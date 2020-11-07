﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentBoundaries
{
    public class GetPaymentResponseBoundary
    {
        [JsonProperty("payment_id")]
        public Guid PaymentId { get; set; }
        [JsonProperty("card_type")]
        public string CardType { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("name")]
        public string NameOnCard { get; set; }
        [JsonProperty("card_number")]
        public int CardNumber { get; set; }
        [JsonProperty("expiry_date")]
        public string ExpiryDate { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("cvv")]
        public int CVV { get; set; }
    }
}