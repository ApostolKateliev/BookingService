using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Post
{
    public class AddPostViewModel
    {
        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        [Required]
        [StringLength(400)]
        public string? Body { get; set; }
    }
}
