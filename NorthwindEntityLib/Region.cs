using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Region
    {

        public Region(){
            Territories = new HashSet<Territory>();
        }
       

        [Key]
        public long RegionID { get; set; }
        [Required]
        public string RegionDescription { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Territory> Territories {get;set;}
        
    }
}
