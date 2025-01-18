using Microsoft.EntityFrameworkCore;
using OnlineShop.Domain.Entites;

namespace OnlineShop.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("SalesLT");
    }
}
