using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Validators
{
    public class CardNumberValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cardNumber = value.ToString();

            if (cardNumber.Length != 16) return false;
            return true;
        }
    }
}
