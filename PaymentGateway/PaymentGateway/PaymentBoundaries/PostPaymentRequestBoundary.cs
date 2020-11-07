using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PaymentGateway.PaymentBoundaries
{
    public class PostPaymentRequestBoundary
    {
        [JsonProperty("card_type")]
        [Required (ErrorMessage = "Failed to supply required information")]
        public string CardType { get; set; }
        [JsonProperty("first_name")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        [Required(ErrorMessage = "Failed to supply required information")]

        public string Address { get; set; }
        [JsonProperty("postcode")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string Postcode { get; set; }
        [JsonProperty("name")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string NameOnCard { get; set; }
        [JsonProperty("card_number")]
        [CreditCard]
        [Required(ErrorMessage = "Failed to supply required information")]
        public int CardNumber { get; set; }
        [JsonProperty("expiry_date")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string ExpiryDate { get; set; }
        [JsonProperty("amount")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string Currency { get; set; }
        [JsonProperty("cvv")]
        [MinLength(3, ErrorMessage = "Invalid card security number")]
        [MaxLength(3, ErrorMessage = "Invalid card security number")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public int CVV { get; set; }
    }
}
