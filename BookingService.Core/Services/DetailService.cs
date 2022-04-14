using BookingService.Core.Contracts;
using BookingService.Core.Models;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class DetailService : IDetailService
    {
        private readonly IApplicationDbRepository repo;
        public DetailService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }
        public async Task<IEnumerable<DetailListViewModel>> GetDetailsList()
        {
            return await repo.All<CarDetail>()
                .Select(c => new DetailListViewModel()
                {
                    Name = c.Name,
                    Specification = c.Specification
                })
                .ToListAsync();
        }

        public async Task<DetailEditViewModel> GetDetailForEdit(int id)
        {
            var detail = await repo.GetByIdAsync<CarDetail>(id);
            return new DetailEditViewModel()
            {
                Id = detail.Id,
                Name = detail.Name,
                Specification = detail.Specification
            };
        }

        public async Task<bool> UpdateDetail(DetailEditViewModel model)
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

        public async Task<bool> AddDetail(AddDetailViewModel model)
        {
            bool result = false;

            var newDetail = new CarDetail
            {
                Name = model.Name,
                Specification = model.Specification
            };

            if (model != null)
            {

                await repo.AddAsync(newDetail);
                await repo.SaveChangesAsync();
                result = true;
            }
             return result;
        }
    }
}
