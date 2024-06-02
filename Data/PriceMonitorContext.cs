namespace PriceMonitor.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PriceMonitor.Domain;

public class PriceMonitorContext : DbContext {
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreProduct> StoreProducts { get; set; }
    public DbSet<StoreProductPrice> StoreProductPrices { get; set; }

    public PriceMonitorContext() {
    }

    public PriceMonitorContext(DbContextOptions<PriceMonitorContext> options) : base(options) {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder
        .UseSqlServer(
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PriceMonitorDatabaseDev")
        .LogTo(
            Console.WriteLine,
            new[] { DbLoggerCategory.Database.Command.Name },
            LogLevel.Information)
        .EnableSensitiveDataLogging();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) {
        configurationBuilder.Properties<DateTime>().HavePrecision(3);
        configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<ProductTag>().Property(p => p.Value).HasMaxLength(300);

        modelBuilder.Entity<Product>().HasMany(p => p.Tags).WithMany();
        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(300);

        modelBuilder.Entity<Store>().Property(s => s.Name).HasMaxLength(300);
        modelBuilder.Entity<Store>().HasData(new[] {
            new Store { StoreId = 1, Name = "Selver" },
            new Store { StoreId = 2, Name = "Rimi" },
        });

        modelBuilder.Entity<StoreProduct>().Property(s => s.ApiString).HasMaxLength(300);
    }
}

