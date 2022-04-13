using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class CarDetailController : BaseController
    {
        private readonly ICarDetailService detailService;

        public CarDetailController(ICarDetailService _detailService)
        {
            detailService = _detailService;
        }


        public async Task<IActionResult> ManageCarDetails()
        {
            var carDetails = await detailService.GetDetailsList();

            return View(carDetails);
        }

        
        public async Task<ActionResult> Edit(int id)
        {
            var detailForEdit = await detailService.GetDetailForEdit(id);

            return View(detailForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CarDetailEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await detailService.UpdateDetail(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the Detail!";

            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";

            }
            return View(model);
        }

    }
}
