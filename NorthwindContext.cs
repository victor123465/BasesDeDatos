using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BasesDeDatos
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CervezaFavorita> CervezaFavorita { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesTerritories> EmployeesTerritories { get; set; }
        public virtual DbSet<InternationalOrders> InternationalOrders { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PagingTest> PagingTest { get; set; }
        public virtual DbSet<PreviousEmployees> PreviousEmployees { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("DataSource=C:\\SQLite\\Northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.CategoryName);

                entity.Property(e => e.CategoryId).ValueGeneratedNever();
            });

            modelBuilder.Entity<CervezaFavorita>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.City);

                entity.HasIndex(e => e.CompanyName);

                entity.HasIndex(e => e.PostalCode);

                entity.HasIndex(e => e.Region);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasIndex(e => e.LastName);

                entity.HasIndex(e => e.PostalCode);

                entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeesTerritories>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.TerritoryId });

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesTerritories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.EmployeesTerritories)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<InternationalOrders>(entity =>
            {
                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.InternationalOrders)
                    .HasForeignKey<InternationalOrders>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasIndex(e => e.OrderId)
                    .HasName("IX_OrderDetails_OrdersOrder_Details");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_OrderDetails_ProductsOrder_Details");

                entity.Property(e => e.Quantity).HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_Orders_CustomersOrders");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("IX_Orders_EmployeesOrders");

                entity.HasIndex(e => e.OrderDate);

                entity.HasIndex(e => e.ShipPostalCode);

                entity.HasIndex(e => e.ShippedDate);

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.Freight).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<PagingTest>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PreviousEmployees>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("IX_Products_CategoriesProducts");

                entity.HasIndex(e => e.ProductName);

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_Products_SuppliersProducts");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Discontinued).HasDefaultValueSql("0");

                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Regions>(entity =>
            {
                entity.Property(e => e.RegionId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasIndex(e => e.CompanyName);

                entity.HasIndex(e => e.PostalCode);

                entity.Property(e => e.SupplierId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Territories>(entity =>
            {
                entity.Property(e => e.TerritoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
