using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models.Booking
{
    public class EditBookingViewModel
    {
        public string Id { get; set; }

        
        public string Date { get; set; }

        public string Service { get; set; }

        public string SpecialRequest { get; set; }
    }
}
