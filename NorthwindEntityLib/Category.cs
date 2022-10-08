using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Category
    {
        [Key]
        public long CategoryID { get; set; }
        [StringLength(15)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        [InverseProperty(nameof(Product.ProductNavigation))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
