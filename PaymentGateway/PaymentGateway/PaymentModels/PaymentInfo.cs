using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentModels
{
    public class PaymentInfo
    {
        public Guid PaymentId { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public CardDetails CardDetails { get; set; }
        public BillingInfo BillingInfo { get; set; }
    }
}
