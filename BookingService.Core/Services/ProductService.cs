using BookingService.Core.Contracts;
using BookingService.Core.Models.Product;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbRepository repo;


        public ProductService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<ProductListViewModel>> GetProductsList()
        {
            return await repo.All<Product>()
                .Select(c => new ProductListViewModel()
                {
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<EditProductViewModel> GetProductForEdit(string id)
        {
            var product = await repo.GetByIdAsync<Product>(id);
            return new EditProductViewModel()
            {
                Id = product.Id.ToString(),
                Name = product.Name,
                Description = product.Description
            };
        }

        public async Task<bool> UpdateProduct(EditProductViewModel model)
        {
            bool result = false;

            var product = await repo.GetByIdAsync<Product>(model.Id);

            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task AddProduct(AddProductViewModel model)
        {


            var newProduct = new Product()
            {
                Name = model.Name,
                Description = model.Description
            };
            try
            {
                await repo.AddAsync<Product>(newProduct);
                await repo.SaveChangesAsync();

            }
            catch (Exception ae)
            {

                throw new Exception("Product wasn`t added!");
            }

        }
    }
}
