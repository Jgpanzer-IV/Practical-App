using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    [Table("Order Details")]
    public partial class OrderDetail
    {
        [Key]
        public long OrderID { get; set; }
        [Key]
        public long ProductID { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public long Quantity { get; set; }
        public double Discount { get; set; }

        [ForeignKey(nameof(OrderID))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(ProductID))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
        
    }
}
