using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class CarDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Specification { get; set; }
    }
}
