
// Namespace to set rules for validation model
using System.ComponentModel.DataAnnotations;



namespace Consuming_Service.Models
{
    public class CustomerViewModel
    {
        [Key]
        [RegularExpression("^[A-Z]{5}$", ErrorMessage = "Please provide your Customer ID correctly.")]
        [Display(Name = "Your Customer-ID")]
        public string CustomerID { get; set;}

        [Required]
        [RegularExpression(@"^\w+$")]
        [MaxLength(64,ErrorMessage = "The Company's name must be maximum at 64 character.")]
        [Display(Name = "Company's Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Please provide your contect name")]
        [StringLength(maximumLength: 64, MinimumLength = 4, ErrorMessage = "Please specify Contect name within range 4 - 64")]
        [Display(Name = "Contact's Name")]
        public string ContactName { get; set; }
            
        [Required(ErrorMessage = "Please specify Contect title for your account.")]
        [Display(Name = "Contact's Title")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "Please specify your shiping's address.")]
        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }
        
        [Required(ErrorMessage = "Please specify postal-code.")]
        [MinLength(3 , ErrorMessage = "The postal-code numeric at least 3 length.")]
        public string PostalCode { get; set; }
        
        public string Country { get; set; }

        [Required (ErrorMessage = "Please provide your valid phone number in order to contect you when shipping arrived.")]
        [Phone]
        public string Phone { get; set; }

        
        public string Fax { get; set; }
    
    }
}
