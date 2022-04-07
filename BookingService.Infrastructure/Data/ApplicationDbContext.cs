using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        

        public DbSet<Craftsman> Craftsmen { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}