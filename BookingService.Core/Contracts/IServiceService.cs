using BookingService.Core.Models.Service;

namespace BookingService.Core.Contracts
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceListViewModel>> GetServicesList();

        Task<EditServiceViewModel> GetServiceForEdit(string id);

        Task<bool> UpdateService(EditServiceViewModel model);
        Task AddService(AddServiceViewModel model);
    }
}
