using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string? Name { get; set; }

        
        [Required]
        [ForeignKey(nameof(Component))]
        public Guid ComponentId { get; set; }
        public Component Component { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
