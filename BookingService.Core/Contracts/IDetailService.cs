using BookingService.Core.Models;

namespace BookingService.Core.Contracts
{
    public interface IDetailService
    {
        Task<IEnumerable<DetailListViewModel>> GetDetailsList();

        Task<DetailEditViewModel> GetDetailForEdit(int id);

        Task<bool> UpdateDetail(DetailEditViewModel model);
        Task<bool> AddDetail(AddDetailViewModel model);

        //Task<bool> AddDetail(AddCarDetailViewModel model);

    }
}
