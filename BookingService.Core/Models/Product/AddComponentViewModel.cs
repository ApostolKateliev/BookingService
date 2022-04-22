using System.ComponentModel.DataAnnotations;


namespace BookingService.Core.Models.Product
{
    public class AddProductViewModel
    {
        
        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
