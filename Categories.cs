using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [Column("CategoryID")]
        public long CategoryId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(15)")]
        public string CategoryName { get; set; }
        [Column(TypeName = "nvarchar")]
        public string Description { get; set; }
        [Column(TypeName = "varbinary")]
        public byte[] Picture { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
