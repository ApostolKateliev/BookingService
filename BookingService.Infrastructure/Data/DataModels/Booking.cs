using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Booking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName = "date")]
        public DateTime Date{ get; set; }

        
        [ForeignKey(nameof(Worker))]
        public Guid WorkerId { get; set; }
        public Worker Worker { get; set; }


        [Required]
        [ForeignKey(nameof(Service))]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

    }
}
