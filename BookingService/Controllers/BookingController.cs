using BookingService.Core.Contracts;
using BookingService.Core.Models.Booking;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IBookingsService service;

        public BookingController(IBookingsService _service)
        {
            service = _service;
        }

        public IActionResult AddBooking()
        {

            ViewBag.ServiceItems = service.ServicesList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(AddBookingViewModel model)
        {

            await service.AddBooking(model);

            
            return View(model);
        }

    }
}
