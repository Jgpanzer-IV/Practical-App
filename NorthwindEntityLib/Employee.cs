using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
            InverseReportsToNavigation = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public long EmployeeID { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
        [StringLength(10)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string Title { get; set; }
        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        [StringLength(60)]
        public string Address { get; set; }
        [StringLength(15)]
        public string City { get; set; }
        [StringLength(15)]
        public string Region { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }
        [StringLength(15)]
        
        public string Country { get; set; }
        [StringLength(24)]
        public string HomePhone { get; set; }
        [StringLength(4)]
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public long? ReportsTo { get; set; }
        [StringLength(255)]  
        public string PhotoPath { get; set; }

        [ForeignKey(nameof(ReportsTo))]
        [InverseProperty(nameof(Employee.InverseReportsToNavigation))]
        public virtual Employee ReportsToNavigation { get; set; }
        
        [InverseProperty(nameof(EmployeeTerritory.Employee))]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
        
        [InverseProperty(nameof(Employee.ReportsToNavigation))]
        public virtual ICollection<Employee> InverseReportsToNavigation { get; set; }
        
        [InverseProperty(nameof(Order.Employee))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
