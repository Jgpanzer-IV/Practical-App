using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Territory
    {
        public Territory()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritory>();
        }

        [Key]
        public string TerritoryID { get; set; }
        [Required]
        public string TerritoryDescription { get; set; }
        public long RegionID { get; set; }

        [ForeignKey(nameof(RegionID))]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
        
        [InverseProperty(nameof(EmployeeTerritory.Territory))]
        public virtual ICollection<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
