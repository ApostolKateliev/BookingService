using BookingService.Core.Contracts;
using BookingService.Core.Models;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class CarDetailService : ICarDetailService
    {
        private readonly IApplicationDbRepository repo;
        public CarDetailService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<CarDetailListViewModel>> GetDetailsList()
        {
            return await repo.All<CarDetail>()
                .Select(c => new CarDetailListViewModel()
                {
                    Name = c.Name,
                    Specification = c.Specification
                })
                .ToListAsync();
        }

        public async Task<CarDetailEditViewModel> GetDetailForEdit(int id)
        {
            var detail = await repo.GetByIdAsync<CarDetail>(id);
            return new CarDetailEditViewModel()
            {
                Id = detail.Id,
                Name = detail.Name,
                Specification = detail.Specification
            };
        }

        public async Task<bool> UpdateDetail(CarDetailEditViewModel model)
        {
            bool result = false;

            var detail = await repo.GetByIdAsync<CarDetail>(model.Id);

            if (detail != null)
            {
                detail.Name = model.Name;
                detail.Specification = model.Specification;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
