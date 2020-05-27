using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class Territories
    {
        public Territories()
        {
            EmployeesTerritories = new HashSet<EmployeesTerritories>();
        }

        [Key]
        [Column("TerritoryID")]
        public long TerritoryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string TerritoryDescription { get; set; }
        [Column("RegionID")]
        public long RegionId { get; set; }

        [ForeignKey(nameof(RegionId))]
        [InverseProperty(nameof(Regions.Territories))]
        public virtual Regions Region { get; set; }
        [InverseProperty("Territory")]
        public virtual ICollection<EmployeesTerritories> EmployeesTerritories { get; set; }
    }
}
