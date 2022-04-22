using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models.Booking
{
    public class BookingListViewModel
    {
        public string Id { get; set; }

        public string Date { get; set; }

        
        public string ContactName { get; set; }

        public string ContactPhoneNumber { get; set; }

        
        public string Service { get; set; }

      
        public string SpecialRequest { get; set; }
    }
}
