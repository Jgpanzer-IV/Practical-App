using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Shipper
    {
        public Shipper()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public long ShipperID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Phone { get; set; }

        [InverseProperty(nameof(Order.ShipViaNavigation))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
