using BookingService.Core.Models.Product;

namespace BookingService.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductListViewModel>> GetProductsList();

        Task<EditProductViewModel> GetProductForEdit(string id);

        Task<bool> UpdateProduct(EditProductViewModel model);
        Task AddProduct(AddProductViewModel model);


    }
}
