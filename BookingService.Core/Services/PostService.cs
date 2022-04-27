using BookingService.Core.Contracts;
using BookingService.Core.Models.Post;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IApplicationDbRepository repo;

        public PostService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddPost(AddPostViewModel model)
        {
            var newPost = new Post()
            {
                Title = model.Title,
                Body = model.Body
            };
            try
            {
                await repo.AddAsync<Post>(newPost);
                await repo.SaveChangesAsync();

            }
            catch (Exception ae)
            {

                throw new Exception("Post wasn`t added!");
            }
        }

        public async Task<EditPostViewModel> GetPostForEdit(string id)
        {
            var post = await repo.GetByIdAsync<Post>(Guid.Parse(id));
            return new EditPostViewModel()
            {
                Id = post.Id.ToString(),
                Body = post.Body,
                Title = post.Title
            };
        }

        public async Task<IEnumerable<PostListViewModel>> GetPostList()
        {
            return await repo.All<Post>()
                .Select(t => new PostListViewModel()
                {
                    Title = t.Title,
                    Body = t.Body
                })
                .ToListAsync();
        }

        public async Task<bool> UpdatePost(EditPostViewModel model)
        {
            bool result = false;

            var post = await repo.GetByIdAsync<Post>(Guid.Parse(model.Id));

            if (post != null)
            {
                post.Title = model.Title;
                post.Body = model.Body;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
