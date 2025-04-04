using FlowerInventory.Models;
using Microsoft.EntityFrameworkCore;

public class FlowerInventoryContext : DbContext
{
    public FlowerInventoryContext(DbContextOptions<FlowerInventoryContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Flower> Flowers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Flower>()
        .Property(f => f.Price)
        .HasColumnType("decimal(18,2)");
    }

}
