using BookingService.Infrastructure.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class AddBookingViewModel
    {
        public string BookingId { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public string NameOfUser { get; set; }

        public int PhoneForContact { get; set; }


    }
}
