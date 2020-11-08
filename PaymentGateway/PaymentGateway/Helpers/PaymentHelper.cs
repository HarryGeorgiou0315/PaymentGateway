using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Helpers
{
    public static class PaymentHelper
    {

        public static string MaskCardNumber(string source)
        {
            var maskedString = "";

            foreach(char s in source)
            {
                maskedString += "X";
            }

            return maskedString;
        }

    }
}
