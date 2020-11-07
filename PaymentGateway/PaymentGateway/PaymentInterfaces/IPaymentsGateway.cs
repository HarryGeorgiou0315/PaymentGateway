using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentInterfaces
{
    public interface IPaymentsGateway
    {
        PostPaymentResponseBoudary ProcessPayment(PostPaymentRequestBoundary request);
        PaymentInfo RetrievePaymentInfo(Guid paymentId);
    }
}
