using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public long OrderID { get; set; }
        [StringLength(5)]
        public string CustomerID { get; set; }
        public long? EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public long? ShipVia { get; set; }
        [Column(TypeName = "money")]
        public decimal? Freight { get; set; }
        [StringLength(40)]
        public string ShipName { get; set; }
        [StringLength(60)]
        public string ShipAddress { get; set; }
        [StringLength(15)] 
        public string ShipCity { get; set; }
        [StringLength(15)]
        public string ShipRegion { get; set; }
        [StringLength(10)]
        public string ShipPostalCode { get; set; }
        [StringLength(15)]
        public string ShipCountry { get; set; }

        [ForeignKey(nameof(CustomerID))]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty("Orders")]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(ShipVia))]
        [InverseProperty(nameof(Shipper.Orders))]
        public virtual Shipper ShipViaNavigation { get; set; }
        
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
