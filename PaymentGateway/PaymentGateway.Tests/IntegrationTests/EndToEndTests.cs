using NUnit.Framework;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.Tests.IntegrationTests.Helpers;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace PaymentGateway.Tests.IntegrationTests
{
    [TestFixture]
    public class EndToEndTests : IntegrationTestsSetup<Startup>
    {
        [Test]
        public void GetShouldReturnSuccess()
        {
            var url = new Uri($"api/payments/{TestResources.ModelSetups.BankSimulatorValidPaymentId1}", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [Test]
        public void PostShouldReturnSuccess()
        {
            var url = new Uri($"/api/payments", UriKind.Relative);
            var content = new ObjectContent<PostPaymentRequestBoundary>
                (TestResources.ModelSetups.PostPaymentRequestBoundarySetup, new JsonMediaTypeFormatter());

            var response = _httpClient.PostAsync(url, content).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
        }

        [Test]
        public void GetShouldReturnBadRequestIfCouldNotRetrievePaymentInfo()
        {
            var url = new Uri($"api/payments/{TestResources.ModelSetups.BankSimulatorInvalidPaymentId}", UriKind.Relative);
            var response = _httpClient.GetAsync(url).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
        }

        [Test]
        public void PostShouldReturnBadRequestIfMalformedCardNumber()
        {
            var url = new Uri($"/api/payments", UriKind.Relative);
            var content = new ObjectContent<PostPaymentRequestBoundary>
                (TestResources.ModelSetups.PostPaymentRequestBoundarySetupWithInvalidCardNumber, new JsonMediaTypeFormatter());

            var response = _httpClient.PostAsync(url, content).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }

        [Test]
        public void PostShouldReturnBadRequestIfMalformedCVVNumber()
        {
            var url = new Uri($"/api/payments", UriKind.Relative);
            var content = new ObjectContent<PostPaymentRequestBoundary>
                (TestResources.ModelSetups.PostPaymentRequestBoundarySetupWithInvalidCVV, new JsonMediaTypeFormatter());

            var response = _httpClient.PostAsync(url, content).Result;

            Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
