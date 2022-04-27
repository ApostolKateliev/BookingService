using BookingService.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Service()
        {
            var services = await service.GetServicesList();

            return View(services);
        }
    }
}
