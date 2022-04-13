using BookingService.Core.Models;

namespace BookingService.Core.Contracts
{
    public interface ICarDetailService
    {
        Task<IEnumerable<CarDetailListViewModel>> GetDetailsList();

        Task<CarDetailEditViewModel> GetDetailForEdit(int id);

        Task<bool> UpdateDetail(CarDetailEditViewModel model);

        //Task<bool> AddDetail(AddCarDetailViewModel model);

    }
}
