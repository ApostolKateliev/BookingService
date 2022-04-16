using BookingService.Core.Models;

namespace BookingService.Core.Contracts
{
    public interface IComponentService
    {
        Task<IEnumerable<ComponentListViewModel>> GetComponentsList();

        Task<EditComponentViewModel> GetComponentForEdit(string id);

        Task<bool> UpdateComponent(EditComponentViewModel model);
        Task<bool> AddComponent(AddComponentViewModel model);

        
    }
}
