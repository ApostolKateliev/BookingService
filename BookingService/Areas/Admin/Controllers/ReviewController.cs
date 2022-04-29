using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class ReviewController : BaseController
    {
        private readonly IReviewService service;

        public ReviewController(IReviewService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> ManageReviews()
        {
            var reviews = await service.GetReviewsList();

            return View(reviews);
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(string id)
        {
            await service.DeleteReview(id);

            return Ok();
        }
    }
}
