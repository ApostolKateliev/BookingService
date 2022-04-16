using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class ComponentController : BaseController
    {
        private readonly IComponentService componentService;

        public ComponentController(IComponentService _componentService)
        {
            componentService = _componentService;
        }


        public async Task<IActionResult> ManageComponents()
        {
            var components = await componentService.GetComponentsList();

            return View(components);
        }

        public IActionResult AddComponent()
        {
            var newComponent = new AddComponentViewModel()
            {
                Name = " ",
                Specification = " "
            };
            
            return View(newComponent);
        }


        public async Task<ActionResult> Edit(string id)
        {
            var componentForEdit = await componentService.GetComponentForEdit(id);

            return View(componentForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditComponentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await componentService.UpdateComponent(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the Component!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddComponentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await componentService.AddComponent(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Added a New Component!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

    }
}
