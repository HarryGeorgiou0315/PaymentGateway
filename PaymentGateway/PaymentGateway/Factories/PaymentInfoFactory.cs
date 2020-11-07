using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentModels;

namespace PaymentGateway.Factories
{
    public static class PaymentInfoFactory
    {
        public static GetPaymentResponseBoundary ToResponseModel(this PaymentInfo paymentInfo)
        {
            return new GetPaymentResponseBoundary
            {
                Address = paymentInfo.BillingInfo.Address,
                Amount = paymentInfo.Amount,
                CardNumber = paymentInfo.CardDetails.CardNumber,
                CardType = paymentInfo.CardDetails.CardType,
                Currency = paymentInfo.Currency,
                CVV = paymentInfo.CardDetails.CVV,
                ExpiryDate = paymentInfo.CardDetails.ExpiryDate,
                FirstName = paymentInfo.BillingInfo.FirstName,
                LastName = paymentInfo.BillingInfo.LastName,
                NameOnCard = paymentInfo.CardDetails.NameOnCard,
                PaymentId = paymentInfo.PaymentId,
                Postcode = paymentInfo.BillingInfo.Postcode
            };
        }
    }
}
