using BookingService.Infrastructure.Data.Enums;
using BookingService.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Vehicle
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(20)]
        public string? Make { get; set; }

        [Required]
        [StringLength(20)]
        public string? Model { get; set; }

        [Required]
        public VehicleType BodyType { get; set; }

    }
}
