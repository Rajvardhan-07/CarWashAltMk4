using CarWashAlt.Models;
using Microsoft.EntityFrameworkCore;

namespace CarWashAlt.Context
{
    public class CarWashAltDbContext : DbContext
    {
        public CarWashAltDbContext(DbContextOptions<CarWashAltDbContext> options) : base(options)
        { }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}
