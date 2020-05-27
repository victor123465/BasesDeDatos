using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class EmployeesTerritories
    {
        [Key]
        [Column("EmployeeID")]
        public long EmployeeId { get; set; }
        [Key]
        [Column("TerritoryID")]
        public long TerritoryId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(Employees.EmployeesTerritories))]
        public virtual Employees Employee { get; set; }
        [ForeignKey(nameof(TerritoryId))]
        [InverseProperty(nameof(Territories.EmployeesTerritories))]
        public virtual Territories Territory { get; set; }
    }
}
