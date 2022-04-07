using BookingService.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        
        [StringLength(40)]
        public string? Name { get; set; }


        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
