using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Post
{
    public class PostListViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(40)]
        public string? Title { get; set; }

        public string? Body { get; set; }


    }
}
