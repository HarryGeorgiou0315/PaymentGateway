using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using PaymentGateway.Validators;

namespace PaymentGateway.PaymentBoundaries
{
    public class PostPaymentRequestBoundary
    {
       
        [Required (ErrorMessage = "Failed to supply required information")]
        [JsonProperty("cardType")]
        public string CardType { get; set; }
        [JsonProperty("firstName")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string LastName { get; set; }
        [JsonProperty("address")]
        [Required(ErrorMessage = "Failed to supply required information")]

        public string Address { get; set; }
        [JsonProperty("postcode")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string Postcode { get; set; }
        [JsonProperty("nameOnCard")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string NameOnCard { get; set; }
        [JsonProperty("cardNumber")]
        [CardNumberValidator(ErrorMessage = "Malformed card number")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string CardNumber { get; set; }
        [JsonProperty("expiryDate")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string ExpiryDate { get; set; }
        [JsonProperty("amount")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public double Amount { get; set; }
        [JsonProperty("currency")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public string Currency { get; set; }
        [JsonProperty("cvv")]
        [CVVValidator(ErrorMessage = "Invalid card security number")]
        [Required(ErrorMessage = "Failed to supply required information")]
        public int CVV { get; set; }
    }
}
