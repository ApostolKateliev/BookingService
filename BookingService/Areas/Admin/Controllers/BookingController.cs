using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingsService bookingService;

        public BookingController(IBookingsService _bookingService)
        {
            bookingService = _bookingService;
        }

        public async Task<IActionResult> ManageBookings()
        {
            var bookings = await bookingService.GetBookingsList();

            return View(bookings);
        }

        
        public async Task<ActionResult> Edit(string id)
        {
            var bookingForEdit = await bookingService.GetBookingForEdit(id);

            return View(bookingForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditBookingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await bookingService.UpdateBookingEdit(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the booking!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }
    }
}
