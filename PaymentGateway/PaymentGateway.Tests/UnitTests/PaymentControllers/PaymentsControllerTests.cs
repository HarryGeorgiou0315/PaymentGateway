using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentControllers;
using PaymentGateway.PaymentInterfaces;
using System;
using System.Net.Http;

namespace PaymentGateway.Tests.UnitTests.PaymentControllers
{
    [TestFixture]
    public class PaymentsControllerTests
    {
        private Mock<IPaymentsLogic> _paymentsLogicMoq;
        private PaymentsController _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _paymentsLogicMoq = new Mock<IPaymentsLogic>();
            _classUnderTest = new PaymentsController(_paymentsLogicMoq.Object);
        }

        [Test]
        public void GetShouldReturnBadRequestRequestExceptionIfRequestFailure()
        {
            _paymentsLogicMoq.Setup(x => x.RetrievePaymentInfo(new Guid())).Throws(new HttpRequestException());

            var result = _classUnderTest.GetPaymentInfo(new Guid()) as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void PostShouldReturnBadRequestRequestExceptionIfRequestFailure()
        {
            _paymentsLogicMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup)).Throws(new HttpRequestException());

            var result = _classUnderTest.PostPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup) as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [Test]
        public void PostShouldReturnInternalServerErrorFailureNotRequestRelated()
        {
            _paymentsLogicMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup)).Throws(It.IsAny<Exception>());

            var result = _classUnderTest.PostPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup) as ObjectResult;

            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public void GetShouldReturnInternalServerErrorFailureNotRequestRelated()
        {
            _paymentsLogicMoq.Setup(x => x.RetrievePaymentInfo(new Guid())).Throws(It.IsAny<Exception>());

            var result = _classUnderTest.GetPaymentInfo(new Guid()) as ObjectResult;

            Assert.AreEqual(500, result.StatusCode);
        }

        [Test]
        public void GetShouldReturnOkResultIfSuccess()
        {
            _paymentsLogicMoq.Setup(x => x.RetrievePaymentInfo(new Guid()))
                                          .Returns(TestResources.ModelSetups.GetPaymentResponseBoundarySetup(new Guid()));

            var result = _classUnderTest.GetPaymentInfo(new Guid()) as OkObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }

        [Test]
        public void PostShouldReturnOkResultIfSuccess()
        {
            _paymentsLogicMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                                          .Returns(TestResources.ModelSetups.PostPaymentResponseBoudarySetup);

            var result = _classUnderTest.PostPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup) as CreatedAtActionResult;

            Assert.AreEqual(201, result.StatusCode);
        }


        [Test]
        public void GetShouldReturnResultOfCorrectReturnTypeIfSuccess()
        {
            _paymentsLogicMoq.Setup(x => x.RetrievePaymentInfo(new Guid()))
                                          .Returns(TestResources.ModelSetups.GetPaymentResponseBoundarySetup(new Guid()));

            var result = _classUnderTest.GetPaymentInfo(new Guid()) as ObjectResult;

            Assert.IsInstanceOf<GetPaymentResponseBoundary>(result.Value);
        }

        [Test]
        public void PostShouldReturnResultOfCorrectReturnTypeIfSuccess()
        {
            _paymentsLogicMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                                          .Returns(TestResources.ModelSetups.PostPaymentResponseBoudarySetup);

            var result = _classUnderTest.PostPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup) as ObjectResult;

            Assert.IsInstanceOf<PostPaymentResponseBoudary>(result.Value);
        }

        [Test]
        public void GetShouldReturnExpectedResultIfRequestSuccess()
        {
            var expectedResult = TestResources.ModelSetups.GetPaymentResponseBoundarySetup(new Guid());

            _paymentsLogicMoq.Setup(x => x.RetrievePaymentInfo(new Guid()))
                                          .Returns(TestResources.ModelSetups.GetPaymentResponseBoundarySetup(new Guid()));

            var response = _classUnderTest.GetPaymentInfo(new Guid()) as ObjectResult;
            var result = response.Value as GetPaymentResponseBoundary;

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
        public void PostShouldReturnExpectedResultIfRequestSuccess()
        {
            var expectedResult = TestResources.ModelSetups.PostPaymentResponseBoudarySetup;

            _paymentsLogicMoq.Setup(x => x.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup))
                                        .Returns(TestResources.ModelSetups.PostPaymentResponseBoudarySetup);

            var response = _classUnderTest.PostPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup) as ObjectResult;

            var result = response.Value as PostPaymentResponseBoudary;

            Assert.AreEqual(expectedResult.PaymentId, result.PaymentId);
        }
    }
}
