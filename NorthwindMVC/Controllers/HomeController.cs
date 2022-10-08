using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindMVC.Models;
using Suntrack.Shared;


namespace NorthwindMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Northwind dbContext;

        public HomeController(ILogger<HomeController> logger, Northwind InjectedDB)
        {
            _logger = logger;
            dbContext = InjectedDB;
        }

        public IActionResult Index()
        {
            HomeIndexViewModel model = new HomeIndexViewModel(
                (uint) new Random().Next(100,10000),
                dbContext.Categories.ToArray(),
                dbContext.Products.Take(10).OrderByDescending(each => each.UnitPrice)
                );

            return View(model);
        }

        
        public IActionResult ProductDetail(int? id){

            if (!id.HasValue){
                return NotFound("There is no route id in the http request. Please specify id for example Home/ProductDetail/1");
            }
            Product product = dbContext.Products.SingleOrDefault(e => e.ProductID == id);
            string getCategory = dbContext.Categories.SingleOrDefault(e => e.CategoryID == product.CategoryID).CategoryName;
            HomeProductDetailVM model = new(){
                product = product,
                category = getCategory
            };

            if (model == null){
                return NotFound("The route id is not valid to searching for product detail. Please use another value.");
            }

            return View(model);
        } 

        [HttpGet]
        public IActionResult CreateProduct(){
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreatedProduct newProduct){
            
            // How to validation model
            HomeCreateProductVM model = new(){
                Product = newProduct,
                Error = !ModelState.IsValid,
                ValidationError = ModelState.Values.SelectMany(state => state.Errors).Select(error => error.ErrorMessage)                
            };

            return View(model);
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
