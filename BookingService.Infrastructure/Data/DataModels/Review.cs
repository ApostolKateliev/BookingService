using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(40)]
        public string? Name { get; set; }

        [Required]
        [StringLength(200)]
        public string? Body { get; set; }

    }
}
