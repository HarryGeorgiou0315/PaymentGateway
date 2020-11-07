using Moq;
using NUnit.Framework;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentInterfaces;
using System;

namespace PaymentGateway.Tests.UnitTests.PaymentsLogic
{
    [TestFixture]
    public class PaymentsLogicTests
    {
        private Mock<IPaymentsGateway> _paymentsGatewayMoq;
        private PaymentLogic.PaymentsLogic _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _paymentsGatewayMoq = new Mock<IPaymentsGateway>();
            _classUnderTest = new PaymentLogic.PaymentsLogic(_paymentsGatewayMoq.Object);
        }
        
        [Test]
        public void ShouldCallCorrectMethodsBasedOnUserInput()
        {
            _paymentsGatewayMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                                            .Returns(It.IsAny<PostPaymentResponseBoudary>());
            _paymentsGatewayMoq.Setup(x => x.RetrievePaymentInfo(It.IsAny<Guid>()))
                                            .Returns(TestResources.ModelSetups.PaymentInfoSetup(It.IsAny<Guid>()));

            _classUnderTest.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup);
            _classUnderTest.RetrievePaymentInfo(new Guid());

            _paymentsGatewayMoq.Verify(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup), Times.Once);
            _paymentsGatewayMoq.Verify(x => x.RetrievePaymentInfo(It.IsAny<Guid>()), Times.Once);
        }

        [Test]
        public void GetShouldReturnResultExpectedBasedOnValidUserInput()
        {
            var testPaymentId = Guid.NewGuid();
            var expectedResult = TestResources.ModelSetups.GetPaymentResponseBoundarySetup(testPaymentId);

            _paymentsGatewayMoq.Setup(x => x.RetrievePaymentInfo(testPaymentId))
                               .Returns(TestResources.ModelSetups.PaymentInfoSetup(testPaymentId));

            var result = _classUnderTest.RetrievePaymentInfo(testPaymentId);

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

        [Test]
        public void PostShouldReturnResultExpectedBasedOnValidUserInput()
        {
            var expectedResult = TestResources.ModelSetups.PostPaymentResponseBoudarySetup;

            _paymentsGatewayMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                                            .Returns(TestResources.ModelSetups.PostPaymentResponseBoudarySetup);

            var result = _classUnderTest.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup);

            Assert.AreEqual(expectedResult.PaymentId, result.PaymentId);
        }

        [Test]
        public void GetShouldThrowExceptionIfFailureOccursWhenRetrievingPaymentInfo()
        {
            _paymentsGatewayMoq.Setup(x => x.RetrievePaymentInfo(new Guid()))
                               .Throws(new Exception());
            Assert.Throws<Exception>(() => _classUnderTest.RetrievePaymentInfo(new Guid()));
        }

        [Test]
        public void PostShouldThrowExceptionIfFailureOccursProcessingNewPayment()
        {
            _paymentsGatewayMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                               .Throws(new Exception());
            Assert.Throws<Exception>(() => _classUnderTest.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup));
        }
    }
}
