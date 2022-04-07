using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [ForeignKey(nameof(Craftsman))]
        public int CraftsmanId { get; set; }
        public Craftsman Craftsman { get; set; }


        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
