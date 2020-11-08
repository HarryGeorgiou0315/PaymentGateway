using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Validators
{
    public class CVVValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var cvv = value.ToString();

            if (cvv.Length != 3) return false;
            return true;
        }
    }
}
