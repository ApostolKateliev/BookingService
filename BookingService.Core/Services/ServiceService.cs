using BookingService.Core.Contracts;
using BookingService.Core.Models;
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
        public async Task<IEnumerable<ServiceListViewModel>> GetServicesList()
        {
            return await repo.All<Service>()
               .Select(c => new ServiceListViewModel()
               {
                   Id = c.Id,
                   Type = c.Type,
                   Duration = c.Duration,
                   CarDetail = c.CarDetail.ToString()
               })
               .ToListAsync();
        }
    }
}
