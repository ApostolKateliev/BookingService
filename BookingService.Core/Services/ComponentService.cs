using BookingService.Core.Contracts;
using BookingService.Core.Models;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IApplicationDbRepository repo;
        public ComponentService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<ComponentListViewModel>> GetComponentsList()
        {
            return await repo.All<Component>()
                .Select(c => new ComponentListViewModel()
                {
                    Name = c.Name,
                    Specification = c.Specification
                })
                .ToListAsync();
        }

        public async Task<EditComponentViewModel> GetComponentForEdit(string id)
        {
            var component = await repo.GetByIdAsync<Component>(id);
            return new EditComponentViewModel()
            {
                Id = component.Id.ToString(),
                Name = component.Name,
                Specification = component.Specification
            };
        }

        public async Task<bool> UpdateComponent(EditComponentViewModel model)
        {
            bool result = false;

            var detail = await repo.GetByIdAsync<Component>(model.Id);

            if (detail != null)
            {
                detail.Name = model.Name;
                detail.Specification = model.Specification;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<bool> AddComponent(AddComponentViewModel model)
        {
            bool result = false;

            var newComponent = new Component
            {
                Name = model.Name,
                Specification = model.Specification
            };

            if (model != null)
            {

                await repo.AddAsync(newComponent);
                await repo.SaveChangesAsync();
                result = true;
            }
             return result;
        }
    }
}
