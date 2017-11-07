using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CarDealer.Data.Models;

namespace CarDealer.Data
{
    public class CarDealerDbContext : IdentityDbContext<User>
    {
        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Car>().ToTable("Cars");
            builder.Entity<Part>().ToTable("Parts");
            builder.Entity<PartCar>().ToTable("PartsCars");
            builder.Entity<Supplier>().ToTable("Suppliers");
            builder.Entity<Sale>().ToTable("Sales");
            builder.Entity<Customer>().ToTable("Customers");

            builder.Entity<PartCar>()
               .HasKey(pc => new { pc.CarId, pc.PartId }); // composite primary key 

        }
    }
}
