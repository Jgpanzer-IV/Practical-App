using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Suntrack.Shared
{
    public partial class Northwind : DbContext
    {
        public Northwind()
        {
        }

        public Northwind(DbContextOptions<Northwind> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=../Northwind.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Freight).HasDefaultValueSql("0");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderID, e.ProductID });

                entity.Property(e => e.Quantity).HasDefaultValueSql("1");

                entity.Property(e => e.UnitPrice).HasDefaultValueSql("0");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductID).ValueGeneratedOnAdd();

                entity.Property(e => e.Discontinued).HasDefaultValueSql("'0'");

                entity.Property(e => e.ReorderLevel).HasDefaultValueSql("0");

                entity.Property(e => e.UnitPrice)
                    .HasDefaultValueSql("0")
                    .HasConversion<double>();

                entity.Property(e => e.UnitsInStock).HasDefaultValueSql("0");

                entity.Property(e => e.UnitsOnOrder).HasDefaultValueSql("0");

                entity.HasOne(d => d.ProductNavigation)
                    .WithMany(b => b.Products)
                    .HasForeignKey(d => d.CategoryID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionID).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
                {
                    entity.HasKey(e => e.TerritoryID);
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
