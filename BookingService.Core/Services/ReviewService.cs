using BookingService.Core.Contracts;
using BookingService.Core.Models.Review;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IApplicationDbRepository repo;

        public ReviewService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task DeleteReview(string id)
        {
            try
            {
                await repo.DeleteAsync<Review>(id);
                await repo.SaveChangesAsync();
            }
            catch (Exception ae)
            {

                throw new Exception("The Review wasn`t deleted!");
            }
        }

        public async Task<IEnumerable<ReviewListViewModel>> GetReviewsList()
        {
            return await repo.All<Review>()
                .Select(r => new ReviewListViewModel()
                {
                    Id = r.Id.ToString(),
                    Name = r.Name,
                    Body = r.Body
                })
                .ToListAsync();
        }

        public async Task AddReview(AddReviewViewModel model)
        {


            var newReview = new Review()
            {
                Name = model.Name,
                Body = model.Body
            };
            try
            {
                await repo.AddAsync<Review>(newReview);
                await repo.SaveChangesAsync();

            }
            catch (Exception ae)
            {

                throw new Exception("The Review wasn`t added!");
            }

        }
    }
}
