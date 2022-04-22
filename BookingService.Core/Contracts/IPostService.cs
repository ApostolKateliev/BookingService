using BookingService.Core.Models.Post;

namespace BookingService.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostListViewModel>> GetPostList();

        Task<EditPostViewModel> GetPostForEdit(string id);

        Task<bool> UpdatePost(EditPostViewModel model);
        Task AddPost(AddPostViewModel model);
    }
}
