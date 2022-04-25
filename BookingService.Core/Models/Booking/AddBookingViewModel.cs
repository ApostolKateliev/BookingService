using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Booking
{
    public class AddBookingViewModel
    {
        public string BookingId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string? NameOfUser { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 9, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string? PhoneForContact { get; set; }

        [Required]
        public string ServiceId { get; set; }

        [StringLength(200, ErrorMessage = "{0} can not be more than {1} characters")]
        public string SpecialRequest { get; set; }


    }
}
