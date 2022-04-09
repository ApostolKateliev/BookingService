using BookingService.Core.Contracts;
using BookingService.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    public class ApplicationUserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IApplicationUserService applicationUserService;

        public ApplicationUserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IApplicationUserService _applicationUserService)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            applicationUserService = _applicationUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await applicationUserService.GetUsersList();

            return Ok();
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
