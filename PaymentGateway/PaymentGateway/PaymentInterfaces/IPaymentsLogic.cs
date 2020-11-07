using PaymentGateway.PaymentBoundaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentInterfaces
{
    public interface IPaymentsLogic
    {
        GetPaymentResponseBoundary RetrievePaymentInfo(Guid paymentId);
        PostPaymentResponseBoudary ProcessPayment(PostPaymentRequestBoundary request);
    }
}
