using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Service
{
    public class AddServiceViewModel
    {
        [Required]
        public string? Name { get; set; }
        public string? Duration { get; set; }
        public string? Price { get; set; }

       
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
