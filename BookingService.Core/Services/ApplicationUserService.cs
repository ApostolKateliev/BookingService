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
        public async Task<IEnumerable<UserList>> GetUsersList()
        {
            return await repo.All<ApplicationUser>()
                .Select(u=> new UserList()
                {
                    Id = u.Id,
                    Email = u.Email
                })
                .ToListAsync();
        }
    }
}
