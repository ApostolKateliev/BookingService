using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Post
{
    public class EditPostViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        [Required]
        [StringLength(400)]
        public string? Body { get; set; }
    }
}
