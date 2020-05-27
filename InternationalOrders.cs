using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class InternationalOrders
    {
        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CustomsDescription { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public byte[] ExciseTax { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty(nameof(Orders.InternationalOrders))]
        public virtual Orders Order { get; set; }
    }
}
