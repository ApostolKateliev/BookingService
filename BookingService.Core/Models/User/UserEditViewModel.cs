using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.User
{
    public class UserEditViewModel
    {
        public string? Id { get; set; }

        
        public string? Name { get; set; }

        
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
    }
}
