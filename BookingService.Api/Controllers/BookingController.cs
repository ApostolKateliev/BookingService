using BookingService.Core.Contracts;
using BookingService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUserBookingService service;

        public BookingController(IUserBookingService _service)
        {
            service = _service;
        }

        [HttpPost]
        [Route("booking")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> BookAService(UserBooking userBooking)
        {
            try
            {
                await service.BookAService(userBooking);
            }
            catch (ArgumentException ae)
            {

                return BadRequest(ae.Message);
            }
            return Ok();
        }
    }
}
