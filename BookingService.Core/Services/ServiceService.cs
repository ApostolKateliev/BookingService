using BookingService.Core.Contracts;
using BookingService.Core.Models.Service;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IApplicationDbRepository repo;

        public ServiceService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddService(AddServiceViewModel model)
        {

            var newService = new Service()
            {
                Name = model.Name,
                Duration = model.Duration,
                Price = model.Price,
                Description = model.Description

            };
            try
            {

                await repo.AddAsync<Service>(newService);
                await repo.SaveChangesAsync();

            }
            catch (Exception ae)
            {

                throw new Exception("Service wasn`t added!");
            }
        }

        public async Task<EditServiceViewModel> GetServiceForEdit(string id)
        {
            var service = await repo.GetByIdAsync<Service>(Guid.Parse(id));
            return new EditServiceViewModel()
            {
                Id = service.Id.ToString(),
                Name = service.Name,
                Duration = service.Duration,
                Price = service.Price,
                Description = service.Description
            };
        }

        public async Task<IEnumerable<ServiceListViewModel>> GetServicesList()
        {
            return await repo.All<Service>()
               .Select(s => new ServiceListViewModel()
               {
                   Id = s.Id.ToString(),
                   Name = s.Name,
                   Duration = s.Duration,
                   Price = s.Price,
                   Description = s.Description
               })
               .ToListAsync();
        }

        public async Task<bool> UpdateService(EditServiceViewModel model)
        {
            bool result = false;

            var service = await repo.GetByIdAsync<Service>(Guid.Parse(model.Id));

            if (service != null)
            {
                service.Name = model.Name;
                service.Duration = model.Duration;
                service.Price = model.Price;
                service.Description = model.Description;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
