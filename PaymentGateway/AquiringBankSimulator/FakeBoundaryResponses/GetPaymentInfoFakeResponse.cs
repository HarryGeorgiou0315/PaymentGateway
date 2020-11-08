using AquiringBankSimulator.BankSimulatorBoundaries;
using AquiringBankSimulator.PaymentModels;
using System;

namespace AquiringBankSimulator.FakeBoundaryResponses
{
    public static class GetPaymentInfoFakeResponse
    {
        public static GetPaymentResponseBoundary GetPaymentInfoFakeResponse1()
        {
            return new GetPaymentResponseBoundary()
            {
                Address = "123 Test Avenue",
                Amount = 100,
                CardNumber = "0000000000000000",
                CardType = "Visa",
                Currency = "GBP",
                CVV = 123,
                ExpiryDate = "10/2020",
                FirstName = "John",
                LastName = "Smith",
                NameOnCard = "MR J Smith",
                Postcode = "T1 1TT",
                PaymentId = Guid.Parse("cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3")
            };
        }

        public static GetPaymentResponseBoundary GetPaymentInfoFakeResponse2()
        {
            return new GetPaymentResponseBoundary()
            {
                Address = "123 Test Avenue",
                Amount = 100,
                CardNumber = "0000000000000000",
                CardType = "Visa",
                Currency = "GBP",
                CVV = 123,
                ExpiryDate = "10/2020",
                FirstName = "John",
                LastName = "Smith",
                NameOnCard = "MR J Smith",
                Postcode = "T1 1TT",
                PaymentId = Guid.Parse("92752c4b-3ab4-4069-a2eb-613efda81a66")
            };
        }

        public static PaymentInfo PaymentInfoFakeResponse1()
        {
            return new PaymentInfo
            {
                PaymentId = Guid.Parse("92752c4b-3ab4-4069-a2eb-613efda81a66"),
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
                    CardNumber = "XXXXXXXXXXXXXXXX",
                    CardType = "Visa",
                    CVV = 123,
                    ExpiryDate = "10/2020",
                    NameOnCard = "MR J Smith"
                },
            };
        }

        public static PaymentInfo PaymentInfoFakeResponse2()
        {
            return new PaymentInfo
            {
                PaymentId = Guid.Parse("cf1f51d5-5cc1-42ab-94f6-a10d0aa25ef3"),
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
                    CardNumber = "XXXXXXXXXXXXXXXX",
                    CardType = "Visa",
                    CVV = 123,
                    ExpiryDate = "10/2020",
                    NameOnCard = "MR J Smith"
                },
            };
        }
    }
}
