using ApiWithRoles.Entities;
using ApiWithRoles.Entities.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiWithRoles.Data
{
    public partial class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    var tableName = entityType.GetTableName();
            //    if (tableName != null && tableName.StartsWith("AspNet"))
            //    {
            //        entityType.SetTableName(tableName.Substring(6)); // bỏ "AspNet"
            //    }
            //}

            //new StudentConfiguration().Configure(modelBuilder.Entity<Student>());

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Brand__DAD4F3BE45F91217");

                entity.ToTable("Brand");

                entity.Property(e => e.BrandName).HasMaxLength(100);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__19093A2B2BEA36D8");

                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__A4AE64B8AC1A112E");

                entity.ToTable("Customer");

                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.CustomerName).HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__C3905BAF0953FB44");

                entity.ToTable("CustomerOrder");

                entity.HasIndex(e => e.OrderCode, "UQ__Customer__999B52291F25872E").IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
                entity.Property(e => e.OrderCode).HasMaxLength(50);
                entity.Property(e => e.OrderDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValue("Pending");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerO__Custo__4F7CD00D");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.ProductId }).HasName("PK__Inventor__ED4863B7D3D377D4");

                entity.ToTable("Inventory");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.LastUpdated)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.QuantityOnHand).HasDefaultValue(0);

                entity.HasOne(d => d.IdNavigation).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Wareh__619B8048");

                entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Produ__628FA481");
            });

            modelBuilder.Entity<InventoryTransaction>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Inventor__55433A4B1EFDF76A");

                entity.ToTable("InventoryTransaction");

                entity.HasIndex(e => e.TransactionCode, "UQ__Inventor__D85E7026EE2857B3").IsUnique();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
                entity.Property(e => e.Notes).HasMaxLength(255);
                entity.Property(e => e.ReferenceId).HasColumnName("ReferenceID");
                entity.Property(e => e.ReferenceTable).HasMaxLength(50);
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValue("Pending");
                entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
                entity.Property(e => e.TransactionCode).HasMaxLength(50);
                entity.Property(e => e.TransactionDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.TransactionType).HasMaxLength(20);
                entity.Property(e => e.WarehouseId).HasColumnName("WarehouseID");

                entity.HasOne(d => d.Customer).WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Inventory__Custo__5812160E");

                entity.HasOne(d => d.Supplier).WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Inventory__Suppl__571DF1D5");

                entity.HasOne(d => d.Warehouse).WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Wareh__5629CD9C");
            });

            modelBuilder.Entity<InventoryTransactionDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Inventor__F2B27FE64015529F");

                entity.ToTable("InventoryTransactionDetail");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product).WithMany(p => p.InventoryTransactionDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__5CD6CB2B");

                entity.HasOne(d => d.Transaction).WithMany(p => p.InventoryTransactionDetails)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__Inventory__Trans__5BE2A6F2");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Model__E8D7A1CC34F95751");

                entity.ToTable("Model");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ModelName).HasMaxLength(200);

                entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Model__BrandID__3F466844");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Product__B40CC6EDEFEDF4A3");

                entity.ToTable("Product");

                entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.BrandId).HasColumnName("BrandID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ModelId).HasColumnName("ModelID");
                entity.Property(e => e.ProductName).HasMaxLength(150);
                entity.Property(e => e.Unit).HasMaxLength(50);
                entity.Property(e => e.VersionId).HasColumnName("VersionID");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandID__45F365D3");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__44FF419A");

                entity.HasOne(d => d.Model).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__Product__ModelID__46E78A0C");

                entity.HasOne(d => d.Version).WithMany(p => p.Products)
                    .HasForeignKey(d => d.VersionId)
                    .HasConstraintName("FK__Product__Version__47DBAE45");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Supplier__4BE66694BE71CFF1");

                entity.ToTable("Supplier");

                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.SupplierName).HasMaxLength(150);
            });

            modelBuilder.Entity<Entities.Version>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Version__16C6402F15B9F77D");

                entity.ToTable("Version");

                entity.Property(e => e.BrandId).HasColumnName("BrandID");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.ModelId).HasColumnName("ModelID");
                entity.Property(e => e.VersionName).HasMaxLength(200);

                entity.HasOne(d => d.Model).WithMany(p => p.Versions)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK__Version__ModelID__4222D4EF");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Warehous__2608AFD97AF4ACD5");

                entity.ToTable("Warehouse");

                entity.Property(e => e.Location).HasMaxLength(255);
                entity.Property(e => e.WarehouseName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        //public DbSet<Student> Students { get; set; }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
