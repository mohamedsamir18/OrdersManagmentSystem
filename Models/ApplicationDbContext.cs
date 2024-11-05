using Microsoft.EntityFrameworkCore;

namespace Orders_Managment_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Order> orders { get; set; }
        public DbSet<Delivery> deliveries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.delivery).WithOne(p => p.order);
            base.OnModelCreating(modelBuilder);
        }
    }
}
