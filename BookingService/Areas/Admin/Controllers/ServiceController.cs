using BookingService.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> ManageServices()
        {
            var services = await service.GetServicesList();

            return View(services);
        }
    }
}
