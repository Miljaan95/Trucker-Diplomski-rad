using AppDemo.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AppDemo.Data
{
    public class DemoDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<DriverProfile> DriverProfile { get; set; }
        public DbSet<Load> Load { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Tour> Tour { get; set; }

        public DemoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

    }
}
