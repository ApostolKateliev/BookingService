using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.Post;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService service;

        public PostController(IPostService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> ManagePosts()
        {
            var posts = await service.GetPostList();

            return View(posts);
        }

        public IActionResult AddPost()
        {

            return View();
        }


        public async Task<ActionResult> Edit(string id)
        {
            var postForEdit = await service.GetPostForEdit(id);

            return View(postForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await service.UpdatePost(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the post!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddPost(AddPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await service.AddPost(model);

            ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Added a New post!";


            return View(model);
        }
    }
}
