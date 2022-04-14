using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class CarDetailController : BaseController
    {
        private readonly IDetailService detailService;

        public CarDetailController(IDetailService _detailService)
        {
            detailService = _detailService;
        }


        public async Task<IActionResult> ManageCarDetails()
        {
            var carDetails = await detailService.GetDetailsList();

            return View(carDetails);
        }

        public IActionResult AddDetail()
        {
            var newDetail = new AddDetailViewModel()
            {
                Name = " ",
                Specification = " "
            };
            
            return View(newDetail);
        }


        public async Task<ActionResult> Edit(int id)
        {
            var detailForEdit = await detailService.GetDetailForEdit(id);

            return View(detailForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DetailEditViewModel model)
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

        [HttpPost]
        public async Task<ActionResult> Add(AddDetailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await detailService.AddDetail(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Added a New Car Detail!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

    }
}
