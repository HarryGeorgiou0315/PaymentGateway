using Newtonsoft.Json;
using PaymentGateway.Factories;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentInterfaces;
using System;

namespace PaymentGateway.PaymentLogic
{
    public class PaymentsLogic : IPaymentsLogic
    {
        IPaymentsGateway _paymentsGateway;

        public PaymentsLogic(IPaymentsGateway paymentsGateway)
        {
            _paymentsGateway = paymentsGateway;
        }

        public PostPaymentResponseBoudary ProcessPayment(PostPaymentRequestBoundary request)
        {
            try
            {
                var result = _paymentsGateway.ProcessPayment(request);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public GetPaymentResponseBoundary RetrievePaymentInfo(Guid paymentId)
        {
            try
            {
                var result = _paymentsGateway.RetrievePaymentInfo(paymentId);
                return result.ToResponseModel();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
