using System.Data.Entity;
using SportNutr.Domain;

public class SportsNutritionDbContext : DbContext
{
    public SportsNutritionDbContext()
        : base("DefaultConnection")
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Определение внешних ключей для отношений между сущностями
        modelBuilder.Entity<Order>()
            .HasRequired(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId);

        modelBuilder.Entity<Order>()
            .HasRequired(o => o.Product)
            .WithMany()
            .HasForeignKey(o => o.ProductId)
            .WillCascadeOnDelete(false); // Предотвращение каскадного удаления продукта при удалении заказа
    }
}