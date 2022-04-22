using BookingService.Core.Models.Booking;

namespace BookingService.Core.Contracts
{
    public interface IBookingsService
    {
        

        Task<IEnumerable<BookingListViewModel>> GetBookingsList();

        Task<EditBookingViewModel> GetBookingForEdit(string id);

        Task<bool> UpdateBookingEdit(EditBookingViewModel model);
    }
}
