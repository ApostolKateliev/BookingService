using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Services;
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

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            await service.DeleteReview(id);
            ViewData[MessageConstant.WarningMessage] = "You Have Deleted the review!";
            return View();
        }
    }
}
