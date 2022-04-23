using BookingService.Core.Models.Review;

namespace BookingService.Core.Contracts
{
    public interface IReviewService
    {
        Task DeleteReview(string id);

        Task<IEnumerable<ReviewListViewModel>> GetReviewsList();
    }
}
