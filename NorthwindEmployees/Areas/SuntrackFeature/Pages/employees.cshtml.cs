using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Suntrack.Shared;

namespace NorthwindEmployees.MyFeature.Pages
{
    public class EmployeePage : PageModel
    {   

        private Northwind contextDB;

        public IEnumerable<Employee> Employees;
        

        public EmployeePage (Northwind injectedContext){
            contextDB = injectedContext;
        }

        public void OnGet()
        {
            ViewData["Title"] = "Employees Information";
            ViewData["toggleID"] = "0";
            
            Employees = contextDB.Employees.ToArray();
        }

    }
}
