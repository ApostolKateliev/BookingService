using BookingService.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Contracts
{
    public interface IBookingsService
    {
        Task<bool> UpdateService(AddBookingViewModel model);
    }
}
