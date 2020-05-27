using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        [Column("ProductID")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string ProductName { get; set; }
        [Column("SupplierID")]
        public long? SupplierId { get; set; }
        [Column("CategoryID")]
        public long? CategoryId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string QuantityPerUnit { get; set; }
        [Column(TypeName = "money")]
        public double UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsInStock { get; set; }
        [Column(TypeName = "smallint")]
        public long? UnitsOnOrder { get; set; }
        [Column(TypeName = "smallint")]
        public long? ReorderLevel { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public int Discontinued { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty(nameof(Categories.Products))]
        public virtual Categories Category { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty(nameof(Suppliers.Products))]
        public virtual Suppliers Supplier { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
