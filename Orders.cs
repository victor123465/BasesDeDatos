using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasesDeDatos
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        [Column("OrderID")]
        public long OrderId { get; set; }
        [Column("CustomerID", TypeName = "nchar(5)")]
        public string CustomerId { get; set; }
        [Column("EmployeeID")]
        public long? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] RequiredDate { get; set; }
        [Column(TypeName = "datetime")]
        public byte[] ShippedDate { get; set; }
        [Column(TypeName = "money")]
        public byte[] Freight { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string ShipName { get; set; }
        [Column(TypeName = "nvarchar(60)")]
        public string ShipAddress { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ShipCity { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ShipRegion { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string ShipPostalCode { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string ShipCountry { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customers.Orders))]
        public virtual Customers Customer { get; set; }
        [InverseProperty("Order")]
        public virtual InternationalOrders InternationalOrders { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
