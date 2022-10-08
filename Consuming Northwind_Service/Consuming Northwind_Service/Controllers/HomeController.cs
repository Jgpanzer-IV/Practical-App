using Consuming_Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Suntrack.Shared;

// For specify problem details
using Microsoft.AspNetCore.Http;

using System.Net.Http;
using System.Net.Http.Json;

namespace Consuming_Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory injectedClient)
        {
            _logger = logger;
            httpClient = injectedClient;
        }


        public async Task<IActionResult> Index()
        {

            var client = httpClient.CreateClient(name: "NorthwindService");

            HttpResponseMessage response = client.GetAsync("api/customers").Result;
                
            if (response.IsSuccessStatusCode) {
                IEnumerable<Customer> customers = await response.Content.ReadFromJsonAsync<IEnumerable<Customer>>();
                IEnumerable<string> country = customers.Select(each => each.Country).Distinct().Where(each => !string.IsNullOrEmpty(each)); ;
                return View(country);
            }

            return View(null);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
