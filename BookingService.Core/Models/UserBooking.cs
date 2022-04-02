using BookingService.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class UserBooking
    {
       
        [Required]
        public DateTime DateAndTime { get; set; }

        
        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public string Service { get; set; }
    }
}
