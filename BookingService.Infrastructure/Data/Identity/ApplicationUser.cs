using BookingService.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        
        [StringLength(40)]
        public string? Name { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
