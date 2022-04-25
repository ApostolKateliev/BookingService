using BookingService.Core.Models.Booking;
using BookingService.Core.Models.Service;

namespace BookingService.Core.Contracts
{
    public interface IBookingsService
    {
        Task AddBooking(AddBookingViewModel model);

        Task<IEnumerable<BookingListViewModel>> GetBookingsList();

        Task<EditBookingViewModel> GetBookingForEdit(string id);

        Task<bool> UpdateBookingEdit(EditBookingViewModel model);

        List<ServiceListViewModel> ServicesList();



    }
}
