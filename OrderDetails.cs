using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class OrderDetails
    {
        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Key]
        [Column("ProductID")]
        public long ProductId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double UnitPrice { get; set; }
        [Column(TypeName = "smallint")]
        public long Quantity { get; set; }
        public double Discount { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.OrderDetails))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Products.OrderDetails))]
        public virtual Products Product { get; set; }
    }
}
