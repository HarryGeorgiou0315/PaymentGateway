using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using PaymentGateway.PaymentGateways;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentGateway.Tests.UnitTests.PaymentGateways
{
    [TestFixture]
    public class PaymentsGatewayTests
    {
        private Mock<HttpMessageHandler> _messageHandler;
        private HttpClient _httpClient;
        private PaymentsGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _messageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_messageHandler.Object)
            {
                BaseAddress = new Uri("http://test.com"),
            };
            _classUnderTest = new PaymentsGateway(_httpClient);
        }

        private void Setup_Http_MessageHander_Response(Mock<HttpMessageHandler> mockMessageHandler, HttpStatusCode httpStatusCode, StringContent content)
        {
            var stubbedResponse = new HttpResponseMessage
            {
                StatusCode = httpStatusCode,
                Content = content
            };

            mockMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                    )
                .ReturnsAsync(stubbedResponse)
                .Verifiable();
        }

        [Test]
        public void PostShouldReturnNewPaymentIdIfResponseSuccess()
        {
            var expectedResult = TestResources.ModelSetups.PostPaymentResponseBoudarySetup;
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.OK,
                new StringContent(JsonConvert.SerializeObject
                            (TestResources.ModelSetups.PostPaymentResponseBoudarySetup)));

            var result = _classUnderTest.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup);

            Assert.AreEqual(expectedResult.PaymentId, result.PaymentId);
        }

        [Test]
        public void GetShouldReturnRetrievedPaymentInfoIfResponseSuccess()
        {
            var testPaymentId = Guid.NewGuid();
            var expectedResult = TestResources.ModelSetups.PaymentInfoSetup(testPaymentId);
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.OK,
                new StringContent(JsonConvert.SerializeObject
                            (TestResources.ModelSetups.PaymentInfoSetup(testPaymentId))));

            var result = _classUnderTest.RetrievePaymentInfo(testPaymentId);

            Assert.AreEqual(expectedResult.PaymentId, result.PaymentId);
            Assert.AreEqual(expectedResult.BillingInfo.FirstName, result.BillingInfo.FirstName);
            Assert.AreEqual(expectedResult.BillingInfo.LastName, result.BillingInfo.LastName);
            Assert.AreEqual(expectedResult.CardDetails.NameOnCard, result.CardDetails.NameOnCard);
            Assert.AreEqual(expectedResult.CardDetails.ExpiryDate, result.CardDetails.ExpiryDate);
            Assert.AreEqual(expectedResult.CardDetails.CVV, result.CardDetails.CVV);
            Assert.AreEqual(expectedResult.CardDetails.CardType, result.CardDetails.CardType);
            Assert.AreEqual(expectedResult.CardDetails.CardNumber, result.CardDetails.CardNumber);
            Assert.AreEqual(expectedResult.BillingInfo.Address, result.BillingInfo.Address);
            Assert.AreEqual(expectedResult.Amount, result.Amount);
            Assert.AreEqual(expectedResult.Currency, result.Currency);
            Assert.AreEqual(expectedResult.BillingInfo.Postcode, result.BillingInfo.Postcode);
        }

        [Test]
        public void PostShouldThrowExceptionIfBadRequest()
        {
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.BadRequest, null);

            Assert.Throws<HttpRequestException>(() => _classUnderTest.ProcessPayment(TestResources.ModelSetups.PostPaymentRequestBoundarySetup));
        }

        [Test]
        public void GetShouldThrowExceptionIfBadRequest()
        {
            var testPaymentId = Guid.NewGuid();
            Setup_Http_MessageHander_Response(_messageHandler, HttpStatusCode.BadRequest, null);

            Assert.Throws<HttpRequestException>(() => _classUnderTest.RetrievePaymentInfo(testPaymentId));
        }
    }
}
