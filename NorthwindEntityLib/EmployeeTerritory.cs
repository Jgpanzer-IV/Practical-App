using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Suntrack.Shared
{
    public partial class EmployeeTerritory
    {
        [Key]
        public long EmployeeID { get; set; }
        [Key]
        public string TerritoryID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty("EmployeeTerritories")]
        public virtual Employee Employee { get; set; }
        
        [ForeignKey(nameof(TerritoryID))]
        [InverseProperty("EmployeeTerritories")]
        public virtual Territory Territory { get; set; }
    }
}
