using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public string Specification { get; set; }
    }
}
