using Newtonsoft.Json;
using PaymentGateway.PaymentBoundaries;
using PaymentGateway.PaymentInterfaces;
using PaymentGateway.PaymentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace PaymentGateway.PaymentGateways
{
    public class PaymentsGateway : IPaymentsGateway
    {
        private HttpClient _httpClient; 

        public PaymentsGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public PostPaymentResponseBoudary ProcessPayment(PostPaymentRequestBoundary request)
        {
            try
            {
                var uri = Environment.GetEnvironmentVariable("AQUIRING_BANK_URL");
                var content = new ObjectContent<PostPaymentRequestBoundary>(request, new JsonMediaTypeFormatter());

                var response =  _httpClient.PostAsync(uri, content).GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                            $"Request failed with status code {response.StatusCode}");
                }
                var result = JsonConvert.DeserializeObject<PostPaymentResponseBoudary>
                                         (response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PaymentInfo RetrievePaymentInfo(Guid paymentId)
        {
            try
            {
                var uri = Environment.GetEnvironmentVariable("AQUIRING_BANK_URL");
                var response =  _httpClient.GetAsync($"{uri}/{paymentId}").GetAwaiter().GetResult();
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(
                            $"Request failed with status code {response.StatusCode}");
                }
                var result = JsonConvert.DeserializeObject<PaymentInfo>
                                         (response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (HttpRequestException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
