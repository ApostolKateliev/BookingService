using BookingService.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            ViewData[MessageConstant.SuccessMessage] = "Welcome!";
            return View();
        }
    }
}
