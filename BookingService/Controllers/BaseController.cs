using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
