using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.User;
using BookingService.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService applicationUserService;

        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _applicationUserService)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            applicationUserService = _applicationUserService;
        }

        
        public async Task<IActionResult> ManageUsers()
        {
            var users = await applicationUserService.GetUsersList();

            return View(users);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var userForEdit = await applicationUserService.GetUserForEdit(id);

            return View(userForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await applicationUserService.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the User!";

            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";

            }
            return View(model);
        }

       

        //Method for creating new roles in the application//

        //public async Task<IActionResult> CreateNewRole()
        //{
        //    await roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Admin"
        //    });
        //    return Ok();
        //}
    }
}
