using System.ComponentModel.DataAnnotations;

namespace BookingService.Core.Models.Booking
{
    public class AddBookingViewModel
    {
        public string BookingId { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        public string? NameOfUser { get; set; }

        public string? PhoneForContact { get; set; }

        public string Service { get; set; }


    }
}
