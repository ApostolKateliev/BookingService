using BookingService.Core.Contracts;
using BookingService.Core.Models;
using BookingService.Infrastructure.Data.Repositories;

namespace BookingService.Core.Services
{
    public class UserBookingService : IUserBookingService
    {
        private readonly ApplicationDbRepository repo;

        public UserBookingService(ApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task BookAService(UserBooking booking)
        {
            throw new NotImplementedException();
        }
    }
}
