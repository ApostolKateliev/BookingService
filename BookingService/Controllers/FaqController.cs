using BookingService.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class FaqController : BaseController
    {
        private readonly IPostService service;

        public FaqController(IPostService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> Faq()
        {
            var posts = await service.GetPostList();

            return View(posts);
        }
    }
}
