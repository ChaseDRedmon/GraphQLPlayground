using Microsoft.EntityFrameworkCore;

namespace GraphQLPlayground.Models;

public partial class AdventureWorksContext : DbContext
{
    public AdventureWorksContext()
    {
    }

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendar> Calendars { get; set; } = null!;

    public virtual DbSet<Category> Categories { get; set; } = null!;

    public virtual DbSet<Customer> Customers { get; set; } = null!;

    public virtual DbSet<Product> Products { get; set; } = null!;

    public virtual DbSet<Return> Returns { get; set; } = null!;

    public virtual DbSet<Sale> Sales { get; set; } = null!;

    public virtual DbSet<Subcategory> Subcategories { get; set; } = null!;

    public virtual DbSet<Territory> Territories { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendar>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Calendar");

            entity.Property(e => e.Date)
                .HasColumnOrder(0)
                .HasColumnType("date");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryKey).HasName("PK__Categori__4B35CDF0679518F5");

            entity.Property(e => e.ProductCategoryKey)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerKey).HasName("PK__Customer__95011E646368A70F");

            entity.Property(e => e.CustomerKey)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.AnnualIncome)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(8);
            entity.Property(e => e.BirthDate)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(4);
            entity.Property(e => e.EducationLevel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(10);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(7);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(2);
            entity.Property(e => e.Gender)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnOrder(6);
            entity.Property(e => e.HomeOwner)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnOrder(12);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(3);
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnOrder(5);
            entity.Property(e => e.Occupation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(11);
            entity.Property(e => e.Prefix)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnOrder(1);
            entity.Property(e => e.TotalChildren).HasColumnOrder(9);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductKey).HasName("PK__Products__A15E99B3690204C7");

            entity.Property(e => e.ProductKey)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.ModelName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(4);
            entity.Property(e => e.ProductColor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnOrder(6);
            entity.Property(e => e.ProductCost).HasColumnOrder(9);
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnOrder(5);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnOrder(3);
            entity.Property(e => e.ProductPrice).HasColumnOrder(10);
            entity.Property(e => e.ProductSize)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnOrder(7);
            entity.Property(e => e.ProductSku)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(2)
                .HasColumnName("ProductSKU");
            entity.Property(e => e.ProductStyle)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnOrder(8);
            entity.Property(e => e.ProductSubcategoryKey).HasColumnOrder(1);
        });

        modelBuilder.Entity<Return>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ProductKey).HasColumnOrder(2);
            entity.Property(e => e.ReturnDate)
                .IsUnicode(false)
                .HasColumnOrder(0);
            entity.Property(e => e.ReturnQuantity).HasColumnOrder(3);
            entity.Property(e => e.TerritoryKey).HasColumnOrder(1);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CustomerKey).HasColumnOrder(4);
            entity.Property(e => e.OrderDate)
                .HasColumnOrder(0)
                .HasColumnType("date");
            entity.Property(e => e.OrderLineItem).HasColumnOrder(6);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnOrder(2);
            entity.Property(e => e.OrderQuantity).HasColumnOrder(7);
            entity.Property(e => e.ProductKey).HasColumnOrder(3);
            entity.Property(e => e.StockDate)
                .HasColumnOrder(1)
                .HasColumnType("date");
            entity.Property(e => e.TerritoryKey).HasColumnOrder(5);
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.ProductSubcategoryKey).HasName("PK__Subcateg__3D21635C002C701F");

            entity.Property(e => e.ProductSubcategoryKey)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.ProductCategoryKey).HasColumnOrder(2);
            entity.Property(e => e.SubcategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(1);
        });

        modelBuilder.Entity<Territory>(entity =>
        {
            entity.HasKey(e => e.SalesTerritoryKey).HasName("PK__Territor__8266AEE94432C839");

            entity.Property(e => e.SalesTerritoryKey)
                .ValueGeneratedNever()
                .HasColumnOrder(0);
            entity.Property(e => e.Continent)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(3);
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(2);
            entity.Property(e => e.Region)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnOrder(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
