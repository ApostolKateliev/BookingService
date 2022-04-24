using BookingService.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService service;

        public ProductController(IProductService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Products()
        {
            var products = await service.GetProductsList();

            return View(products);
        }
    }
}
