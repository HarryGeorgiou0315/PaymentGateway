using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentModels;
using System;

namespace PaymentGateway.Tests.TestResources
{
    public static class ModelSetups
    {
        // some guids I know will work for testing for success when running integration tests. 
        public static Guid BankSimulatorValidPaymentId1 = Guid.Parse("cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3");
        public static Guid BankSimulatorValidPaymentId2 = Guid.Parse("92752c4b-3ab4-4069-a2eb-613efda81a66");

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

