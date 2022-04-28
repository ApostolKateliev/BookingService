using BookingService.Core.Contracts;
using BookingService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookingService.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReviewService _service;


        public HomeController(ILogger<HomeController> logger, IReviewService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public async Task<IActionResult> About()
        {
            var reviews = await _service.GetReviewsList();
            return View(reviews);
        }
        

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}