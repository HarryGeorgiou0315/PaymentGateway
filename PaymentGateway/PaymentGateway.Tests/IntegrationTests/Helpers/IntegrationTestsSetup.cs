using NUnit.Framework;
using System;
using System.Net.Http;

namespace PaymentGateway.Tests.IntegrationTests.Helpers
{
    public class IntegrationTestsSetup<TStartup> where TStartup : class
    {
        private MockWeatherApiFactory<TStartup> _factory;
        protected HttpClient _httpClient { get; private set; }

        [SetUp]
        public void Setup()
        {
            //Environment.SetEnvironmentVariable("AQUIRING_BANK_URL", "http://127.0.0.1:3001"); //uncomment to be able to test locally.
            _factory = new MockWeatherApiFactory<TStartup>();
            _httpClient = _factory.CreateClient();
        }

        [TearDown]
        public void Teardown()
        {
            _httpClient.Dispose();
            _factory.Dispose();
        }
    }
}
