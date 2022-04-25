using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class ServiceController : BaseController
    {
        private readonly IServiceService service;

        public ServiceController(IServiceService _service)
        {
            service = _service;
        }

        public async Task<IActionResult> ManageServices()
        {
            var services = await service.GetServicesList();

            return View(services);
        }

        public IActionResult AddService()
        {
            
            return View();
        }


        public async Task<ActionResult> EditService(string id)
        {
            var serviceForEdit = await service.GetServiceForEdit(id);

            return View(serviceForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> EditService(EditServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await service.UpdateService(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the Service!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddService(AddServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await service.AddService(model);

            ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Added a New Service!";


            return View(model);
        }

    }
}
