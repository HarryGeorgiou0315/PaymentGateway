using NUnit.Framework;
using PaymentGateway.Factories;
using System;

namespace PaymentGateway.Tests.UnitTests.Factories
{
    [TestFixture]
    public class PaymentInfoFactoryTests
    {
        [Test]
        public void ShouldConvertPaymentInfoToGetPaymentResponseBoundary()
        {
            var expectedResult = TestResources.ModelSetups.GetPaymentResponseBoundarySetup(new Guid());

            var result = TestResources.ModelSetups.PaymentInfoSetup(new Guid()).ToResponseModel();

            Assert.AreEqual(expectedResult.PaymentId, result.PaymentId);
            Assert.AreEqual(expectedResult.FirstName, result.FirstName);
            Assert.AreEqual(expectedResult.LastName, result.LastName);
            Assert.AreEqual(expectedResult.NameOnCard, result.NameOnCard);
            Assert.AreEqual(expectedResult.ExpiryDate, result.ExpiryDate);
            Assert.AreEqual(expectedResult.CVV, result.CVV);
            Assert.AreEqual(expectedResult.CardType, result.CardType);
            Assert.AreEqual(expectedResult.CardNumber, result.CardNumber);
            Assert.AreEqual(expectedResult.Address, result.Address);
            Assert.AreEqual(expectedResult.Amount, result.Amount);
            Assert.AreEqual(expectedResult.Currency, result.Currency);
            Assert.AreEqual(expectedResult.Postcode, result.Postcode);
        }
    }
}
