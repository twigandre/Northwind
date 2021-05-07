using System;
using Microsoft.EntityFrameworkCore;
using Northwind.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Northwind.Database
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

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<UsState> UsStates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=Northwind;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Picture).HasColumnName("picture");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("char")
                    .HasColumnName("customer_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(30)
                    .HasColumnName("contact_name");

                entity.Property(e => e.ContactTitle)
                    .HasMaxLength(30)
                    .HasColumnName("contact_title");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .HasColumnName("fax");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.CustomerTypeId })
                    .HasName("pk_customer_customer_demo");

                entity.ToTable("customer_customer_demo");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("char")
                    .HasColumnName("customer_id");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnType("char")
                    .HasColumnName("customer_type_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerCustomerDemos)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_customer_demo_customers");

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.CustomerCustomerDemos)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_customer_demo_customer_demographics");
            });

            modelBuilder.Entity<CustomerDemographic>(entity =>
            {
                entity.HasKey(e => e.CustomerTypeId)
                    .HasName("pk_customer_demographics");

                entity.ToTable("customer_demographics");

                entity.Property(e => e.CustomerTypeId)
                    .HasColumnType("char")
                    .HasColumnName("customer_type_id");

                entity.Property(e => e.CustomerDesc).HasColumnName("customer_desc");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Extension)
                    .HasMaxLength(4)
                    .HasColumnName("extension");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("first_name");

                entity.Property(e => e.HireDate)
                    .HasColumnType("date")
                    .HasColumnName("hire_date");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(24)
                    .HasColumnName("home_phone");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("last_name");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.PhotoPath)
                    .HasMaxLength(255)
                    .HasColumnName("photo_path");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");

                entity.Property(e => e.ReportsTo).HasColumnName("reports_to");

                entity.Property(e => e.Title)
                    .HasMaxLength(30)
                    .HasColumnName("title");

                entity.Property(e => e.TitleOfCourtesy)
                    .HasMaxLength(25)
                    .HasColumnName("title_of_courtesy");

                entity.HasOne(d => d.ReportsToNavigation)
                    .WithMany(p => p.InverseReportsToNavigation)
                    .HasForeignKey(d => d.ReportsTo)
                    .HasConstraintName("fk_employees_employees");
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.TerritoryId })
                    .HasName("pk_employee_territories");

                entity.ToTable("employee_territories");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.TerritoryId)
                    .HasMaxLength(20)
                    .HasColumnName("territory_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_territories_employees");

                entity.HasOne(d => d.Territory)
                    .WithMany(p => p.EmployeeTerritories)
                    .HasForeignKey(d => d.TerritoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_territories_territories");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("char")
                    .HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.Freight).HasColumnName("freight");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("date")
                    .HasColumnName("required_date");

                entity.Property(e => e.ShipAddress)
                    .HasMaxLength(60)
                    .HasColumnName("ship_address");

                entity.Property(e => e.ShipCity)
                    .HasMaxLength(15)
                    .HasColumnName("ship_city");

                entity.Property(e => e.ShipCountry)
                    .HasMaxLength(15)
                    .HasColumnName("ship_country");

                entity.Property(e => e.ShipName)
                    .HasMaxLength(40)
                    .HasColumnName("ship_name");

                entity.Property(e => e.ShipPostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("ship_postal_code");

                entity.Property(e => e.ShipRegion)
                    .HasMaxLength(15)
                    .HasColumnName("ship_region");

                entity.Property(e => e.ShipVia).HasColumnName("ship_via");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shipped_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_employees");

                entity.HasOne(d => d.ShipViaNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipVia)
                    .HasConstraintName("fk_orders_shippers");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("pk_order_details");

                entity.ToTable("order_details");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Discontinued).HasColumnName("discontinued");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("product_name");

                entity.Property(e => e.QuantityPerUnit)
                    .HasMaxLength(20)
                    .HasColumnName("quantity_per_unit");

                entity.Property(e => e.ReorderLevel).HasColumnName("reorder_level");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.UnitsInStock).HasColumnName("units_in_stock");

                entity.Property(e => e.UnitsOnOrder).HasColumnName("units_on_order");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_products_categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_products_suppliers");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("region");

                entity.Property(e => e.RegionId)
                    .ValueGeneratedNever()
                    .HasColumnName("region_id");

                entity.Property(e => e.RegionDescription)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("region_description");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("shippers");

                entity.Property(e => e.ShipperId)
                    .ValueGeneratedNever()
                    .HasColumnName("shipper_id");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("company_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId)
                    .ValueGeneratedNever()
                    .HasColumnName("supplier_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("company_name");

                entity.Property(e => e.ContactName)
                    .HasMaxLength(30)
                    .HasColumnName("contact_name");

                entity.Property(e => e.ContactTitle)
                    .HasMaxLength(30)
                    .HasColumnName("contact_title");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Fax)
                    .HasMaxLength(24)
                    .HasColumnName("fax");

                entity.Property(e => e.Homepage).HasColumnName("homepage");

                entity.Property(e => e.Phone)
                    .HasMaxLength(24)
                    .HasColumnName("phone");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .HasColumnName("postal_code");

                entity.Property(e => e.Region)
                    .HasMaxLength(15)
                    .HasColumnName("region");
            });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.ToTable("territories");

                entity.Property(e => e.TerritoryId)
                    .HasMaxLength(20)
                    .HasColumnName("territory_id");

                entity.Property(e => e.RegionId).HasColumnName("region_id");

                entity.Property(e => e.TerritoryDescription)
                    .IsRequired()
                    .HasColumnType("char")
                    .HasColumnName("territory_description");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Territories)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_territories_region");
            });

            modelBuilder.Entity<UsState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("pk_usstates");

                entity.ToTable("us_states");

                entity.Property(e => e.StateId)
                    .ValueGeneratedNever()
                    .HasColumnName("state_id");

                entity.Property(e => e.StateAbbr)
                    .HasMaxLength(2)
                    .HasColumnName("state_abbr");

                entity.Property(e => e.StateName)
                    .HasMaxLength(100)
                    .HasColumnName("state_name");

                entity.Property(e => e.StateRegion)
                    .HasMaxLength(50)
                    .HasColumnName("state_region");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
