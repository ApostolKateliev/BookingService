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

        [StringLength(40)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string ContactPhoneNumber { get; set; }

        [Required]
        [ForeignKey(nameof(Service))]
        public Guid ServiceId { get; set; }
        public Service Service { get; set; }

        [StringLength(200)]
        public string SpecialRequest { get; set; }

    }
}
