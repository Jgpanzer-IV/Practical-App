using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // For model validation

namespace NorthwindMVC.Models
{
    public class HomeCreateProductVM
    {
        public CreatedProduct Product{get;set;} 
        public bool Error {get;set;}
        public IEnumerable<string> ValidationError{get;set;}
        
    }

    public class CreatedProduct{
        [Required]
        public string ProductName {get;set;}
        [Range(0,1000)]
        public string UnitPrice {get;set;}
        [Required]
        public string UnitInStock{get;set;}

        public bool Discontinue{get;set;}

    }
}