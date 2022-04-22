using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class BookingController : BaseController
    {
        
        public IActionResult AddBooking()
        {
            return View();
        }


    }
}
