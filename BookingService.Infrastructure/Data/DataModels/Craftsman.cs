using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Craftsman
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
