using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Suntrack.Shared;

using System.Net.Http;
using System.Net.Http.Json;

namespace WPFConsumeService.service
{
    public class ConsumerAPI
    {

        private static ConsumerAPI consumerAPI;
        private HttpClient client;

        private ConsumerAPI()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5002/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static ConsumerAPI getObject() {
            
            if (consumerAPI == null)
                consumerAPI = new();
             
            return consumerAPI;
        }

        public IEnumerable<string> getAllCustomer() {

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,"api/customers/");

            HttpResponseMessage response = client.SendAsync(request).Result;

            IEnumerable<string> listCustomer = null;
            if (response.IsSuccessStatusCode) {
                listCustomer = response.Content.ReadFromJsonAsync<IEnumerable<Customer>>()
                    .Result
                    .Select(each => each.ContactName);
            }

            return listCustomer;
        }

        

    }
}
