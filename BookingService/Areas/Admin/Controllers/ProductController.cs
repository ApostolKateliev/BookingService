using BookingService.Core.Constants;
using BookingService.Core.Contracts;
using BookingService.Core.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace BookingService.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }


        public async Task<IActionResult> ManageProducts()
        {
            var products = await productService.GetProductsList();

            return View(products);
        }

        public IActionResult AddProduct()
        {

            return View();
        }


        public async Task<ActionResult> Edit(string id)
        {
            var productForEdit = await productService.GetProductForEdit(id);

            return View(productForEdit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (await productService.UpdateProduct(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Edited the product!";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "An error occurred!";
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await productService.AddProduct(model);

            ViewData[MessageConstant.SuccessMessage] = "You Have Successfully Added a New product!";


            return View(model);
        }

    }
}
