using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.Base
{
    public class RentalCarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<RentProcess> RentProcesses { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RentalCar;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentProcess>().HasOne(r => r.Car)
            .WithMany()
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RentProcess>()
            .HasOne(r => r.Company)
            .WithMany()
            .HasForeignKey(r => r.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

          modelBuilder.Entity<Car>()
                .HasOne(r => r.Brand)
                .WithMany()
                .HasForeignKey(r => r.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
