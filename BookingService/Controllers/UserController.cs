using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
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
        public async Task<IActionResult> CreateNewRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "Admin"
            });
            ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Created a New Role!";
            return Ok();
        }
    }
}
