using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class Regions
    {
        public Regions()
        {
            Territories = new HashSet<Territories>();
        }

        [Key]
        [Column("RegionID")]
        public long RegionId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string RegionDescription { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<Territories> Territories { get; set; }
    }
}
