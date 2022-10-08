using Microsoft.AspNetCore.Mvc.RazorPages;
using Suntrack.Shared;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages{


    public class CustommerPage : PageModel{

        private Northwind contextDB {get; set;} 
        public IEnumerable<Customer> customers {get; private set;}
        public IEnumerable<string> countryies{get; private set;}

        [BindProperty]
        public Customer customer {get;set;}

        public CustommerPage(Northwind injectedDBContext){
            contextDB = injectedDBContext;
        }

        public void OnGet(string country = "All"){
            countryies = contextDB.Customers.Select(each => each.Country).Where(each => each.Length > 0).Distinct();
            ViewData["selectedCountry"] = country;
            
            if (country != "All")
                customers = contextDB.Customers
                    .Include(each => each.Orders)
                    .Where(each => each.Country == country);
            else{
                customers = contextDB.Customers.Include(each => each.Orders);
                //.AsEnumerable().GroupJoin(
                //     inner: contextDB.Orders,
                //     outerKeySelector: each => each.CustomerID,
                //     innerKeySelector: eachOrder => eachOrder.CustomerID,
                //     resultSelector: (custommer, orderMached) => new{
                //         customer.ContactName,
                //         orderMached
                //     }
                // ).
            }
        }

        public void OnPost(){

        }

        public IActionResult OnPostView(string country){
            
            // Redirec to Get Method handler and send parameter name 'country'
            return RedirectToPage("/custommers",new {country = country});

        }

    }



}