using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Post
{
    public class PostListViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        
    }
}
