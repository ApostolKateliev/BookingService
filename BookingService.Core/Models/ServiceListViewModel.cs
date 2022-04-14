using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class ServiceListViewModel
    {
       
        public int Id { get; set; }

        
        public string? Type { get; set; }

        public TimeSpan Duration { get; set; }

        public string? CarDetail { get; set; }
    }
}
