using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Suntrack.Shared;

using System.Net.Http;
using System.Net.Http.Json;

namespace Consuming_Service.Controllers
{
    public class CustomerController : Controller
    {
        private IHttpClientFactory clientFactory;
        private readonly string customerControllerUrl;

        public CustomerController(IHttpClientFactory injectedHttpClient) {
            clientFactory = injectedHttpClient;
            customerControllerUrl = "api/customers";
        }

        public async Task<IActionResult> CustomerByID(string id)
        {

            if (string.IsNullOrEmpty(id))
                return View(null);

            string requestUrl = customerControllerUrl + "/" + id;

            var client = clientFactory.CreateClient(name: "NorthwindService");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: requestUrl
                );

            HttpResponseMessage responce = await client.SendAsync(request);

            if (responce.IsSuccessStatusCode)
            {
                Customer obj = await responce.Content.ReadFromJsonAsync<Customer>();
                return View(obj);
            }
            ViewData["errorID"] = id;
            return View(null);
        }

        public async Task<IActionResult> AllCustomers(string country)
        {

            string url = string.Empty;

            // If it not has id but country, then search by the country
            if (!string.IsNullOrEmpty(country))
            {
                url = customerControllerUrl + "?country=" + country;
                ViewData["Title"] = "Customer - " + country;
                ViewData["ListBy"] = "Country " + country;
            }

            // If it not has any value specified, then search all customers
            else
            {
                url = customerControllerUrl;
                ViewData["Title"] = "Customer - All";
                ViewData["ListBy"] = "All";
            }


            // Create http client instance
            var client = clientFactory.CreateClient(name: "NorthwindService");

            // Create request instance from 'HttpRequestMessage class'
            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: url
            );

            // Create response instance from client sent the request
            HttpResponseMessage response = await client.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
                return View(model);
            }

            return NotFound();
        }


        [HttpGet]
        public IActionResult CreateCustomer() {
      
            ViewData["countries"] = Service.APIService.Countries;
            return View();
           
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Models.CustomerViewModel customer) {

            ViewData["countries"] = Service.APIService.Countries;
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            string url = customerControllerUrl;

            var client = clientFactory.CreateClient("NorthwindService");

            var response = client.PostAsJsonAsync<Models.CustomerViewModel> (url, customer).Result;

            if (response.IsSuccessStatusCode) // 200 / 201
            {
                Models.CustomerViewModel created = await response.Content.ReadFromJsonAsync<Models.CustomerViewModel>();
                return RedirectToAction(nameof(CustomerByID), new { id = created.CustomerID });
            }

            TempData["ApiError"] = "true";
             return View();
        }


    }
}
