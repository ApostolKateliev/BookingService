using BookingService.Core.Contracts;
using BookingService.Core.Models.Review;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService service;

        public ReviewController(IReviewService _service)
        {
            service = _service;
        }

        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewViewModel model)
        {

            await service.AddReview(model);

            ModelState.Clear();
            return View(model);
        }
    }
}
