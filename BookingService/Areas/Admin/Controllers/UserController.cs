using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.User;
using BookingService.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public async Task<IActionResult> Roles(string id)
        {
            var user = await applicationUserService.GetUserById(id);
            var model = new UserRoleViewModel()
            {
                Id = user.Id,
                Name = user.Name
            };


            ViewBag.RoleItems = roleManager.Roles
                .ToList()
                .Select(r => new SelectListItem()
                {
                    Text = r.Name,
                    Value = r.Name,
                    Selected = userManager.IsInRoleAsync(user, r.Name).Result
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Roles(UserRoleViewModel model)
        {
            var user = await applicationUserService.GetUserById(model.Id);
            var userRoles = await userManager.GetRolesAsync(user);
            await userManager.RemoveFromRolesAsync(user, userRoles);

            if (model.Roles?.Length > 0)
            {
                await userManager.AddToRolesAsync(user, model.Roles);
            }

            return RedirectToAction(nameof(ManageUsers));
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
