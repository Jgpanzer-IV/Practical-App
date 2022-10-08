using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Suntrack.Shared;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindWeb.Pages{

    public class SuppliersModel: PageModel {

        public IEnumerable<QueryModel> Suppliers {get; private set; }
        private Northwind contextDB;

        [BindProperty]
        public QueryModel Form{get;set;}

        public SuppliersModel(Northwind injectedContext){
            contextDB = injectedContext;
        }
        public IActionResult OnPost(){
            
            if (ModelState.IsValid) {
                Supplier obj = new Supplier(){
                    CompanyName = Form.CompanyName,
                    ContactName = Form.ContactName,
                    City = Form.City,
                    Address = Form.Address
                };
                contextDB.Suppliers.Add(obj);
                contextDB.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
        public void Onget() { 
            
            ViewData["Title"] = "Northwind - Supplier";
            ViewData["Author"]= "Karnchai Sakkkarnjana";

            Suppliers = contextDB.Suppliers.Select(entity => new QueryModel(){
                CompanyName = entity.CompanyName,
                ContactName = entity.ContactName,
                City = entity.City,
                Address = entity.Address
            });
        }

        

    }

    public class QueryModel{
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

    }




}