using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public long ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [StringLength(40)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "NUMERIC")]
        public decimal? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool? Discontinued { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category ProductNavigation { get; set; }
        public long? CategoryID { get; set; }

        [ForeignKey(nameof(SupplierID))]
        [InverseProperty("Products")]
        public virtual Supplier Supplier { get; set; }
        public long? SupplierID { get; set; }


        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
