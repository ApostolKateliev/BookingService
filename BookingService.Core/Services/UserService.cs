using BookingService.Core.Contracts;
using BookingService.Core.Models.User;
using BookingService.Infrastructure.Data.Identity;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationDbRepository repo;

        public UserService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task<UserEditViewModel> GetUserForEdit(string id)
        {
            var user = await repo.GetByIdAsync<ApplicationUser>(id);
            return new UserEditViewModel() 
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
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
                    PhoneNumber = u.PhoneNumber,
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
                user.PhoneNumber = model.PhoneNumber;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await repo.GetByIdAsync<ApplicationUser>(id);
            
        }
    }
}
