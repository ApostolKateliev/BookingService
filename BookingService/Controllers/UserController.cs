using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    //When not in use change to INTERNAL and comment ... and when needed change to PUBLIC
    internal class UserController : BaseController
    {
        //private readonly RoleManager<IdentityRole> roleManager;

        
        //public UserController(RoleManager<IdentityRole> _roleManager)
        //{
        //    roleManager = _roleManager;
            
        //}
        //public IActionResult Index()
        //{
        //    return View();
        //}
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
