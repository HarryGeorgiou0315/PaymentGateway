using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentModels
{
    public class CardDetails
    {
        public string NameOnCard { get; set; }
        public int CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int CVV { get; set; }
        public string CardType { get; set; }
    }
}
