using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }


        [StringLength(200)]
        public string? Description { get; set; }
    }
}
