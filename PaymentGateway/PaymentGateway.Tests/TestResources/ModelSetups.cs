using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentModels;
using System;

namespace PaymentGateway.Tests.TestResources
{
    public static class ModelSetups
    {
        public static PostPaymentRequestBoundary PostPaymentRequestBoundarySetup = new PostPaymentRequestBoundary
        {
             Address = "123 Test Avenue",
             Amount = 100, 
             CardNumber = 0000000000000000,
             CardType = "Visa",
             Currency = "GBP",
             CVV = 123,
             ExpiryDate = "10/2020",
             FirstName = "John",
             LastName = "Smith",
             NameOnCard = "MR J Smith",
             Postcode = "T1 1TT"
        };

        public static PostPaymentResponseBoudary PostPaymentResponseBoudarySetup = new PostPaymentResponseBoudary
        {
            PaymentId = new Guid()
        };

        public static GetPaymentResponseBoundary GetPaymentResponseBoundarySetup(Guid guid)
        {
            return new GetPaymentResponseBoundary()
            {
                Address = "123 Test Avenue",
                Amount = 100,
                CardNumber = 0000000000000000,
                CardType = "Visa",
                Currency = "GBP",
                CVV = 123,
                ExpiryDate = "10/2020",
                FirstName = "John",
                LastName = "Smith",
                NameOnCard = "MR J Smith",
                Postcode = "T1 1TT",
                PaymentId = guid
           };
        }

        public static PaymentInfo PaymentInfoSetup(Guid guid)
        {
            return new PaymentInfo
            {
                PaymentId = guid,
                Amount = 100,
                Currency = "GBP",

                BillingInfo = new BillingInfo
                {
                    Address = "123 Test Avenue",
                    FirstName = "John",
                    LastName = "Smith",
                    Postcode = "T1 1TT"
                },
                CardDetails = new CardDetails
                {
                    CardNumber = 0000000000000000,
                    CardType = "Visa",
                    CVV = 123,
                    ExpiryDate = "10/2020",
                    NameOnCard = "MR J Smith"
                },
            };
        } 
    }
}

