using System.Data.Entity;

namespace ExcellentTaste.Models
{
    public class ExcellentTasteContext : DbContext
    {
        public ExcellentTasteContext() : base("DefaultConnection")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodOption> FoodOptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}