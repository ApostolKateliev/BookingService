using BookingService.Core.Contracts;
using BookingService.Core.Models;
using BookingService.Infrastructure.Data.Identity;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationDbRepository repo;

        public ApplicationUserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);
            return new UserEditViewModel() 
            {
                Id = user.Id,
                Name = user.Name 
            };
        }

        public async Task<IEnumerable<UserListViewModel>> GetUsersList()
        {
            return await repo.All<ApplicationUser>()
                .Select(u=> new UserListViewModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateUser(UserEditViewModel model)
        {
            bool result = false;

            var user = await repo.GetByIdAsync<ApplicationUser>(model.Id);

            if (user != null)
            {
                user.Name = model.Name;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}
