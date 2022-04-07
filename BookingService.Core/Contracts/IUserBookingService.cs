using BookingService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Contracts
{
    public interface IUserBookingService
    {
        Task BookAService(UserBooking booking);
    }
}
