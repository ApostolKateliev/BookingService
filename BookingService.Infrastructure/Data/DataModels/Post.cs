using System.ComponentModel.DataAnnotations;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        [Required]
        [StringLength(400)]
        public string? Body { get; set; }

    }
}
