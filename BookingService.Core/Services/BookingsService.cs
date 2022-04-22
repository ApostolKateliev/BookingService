using BookingService.Core.Contracts;
using BookingService.Core.Models.Booking;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class BookingsService : IBookingsService
    {

        private readonly IApplicationDbRepository repo;

        public BookingsService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<EditBookingViewModel> GetBookingForEdit(string id)
        {
            var booking = await repo.GetByIdAsync<Booking>(id);
            return new EditBookingViewModel()
            {
                Id = booking.Id.ToString(),
                Date = booking.Date.ToString(),
                Service = booking.Service.Name,
                SpecialRequest = booking.SpecialRequest
            };
        }

        public async Task<IEnumerable<BookingListViewModel>> GetBookingsList()
        {
            return await repo.All<Booking>()
                .Select(b => new BookingListViewModel()
                {
                    Date = b.Date.ToString(),
                    ContactName = b.ContactName,
                    ContactPhoneNumber = b.ContactPhoneNumber,
                    Service = b.Service.Name,
                    SpecialRequest = b.SpecialRequest
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateBookingEdit(EditBookingViewModel model)
        {
            bool result = false;

            var booking = await repo.GetByIdAsync<Booking>(model.Id);
            var bookingDate = booking.Date.ToString();
            if (booking != null)
            {
                
                bookingDate = model.Date;
                booking.Service.Name = model.Service;
                booking.SpecialRequest = model.SpecialRequest;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        
    }
}
