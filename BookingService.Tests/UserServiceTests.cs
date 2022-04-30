using BookingService.Core.Contracts;
using BookingService.Core.Services;
using BookingService.Infrastructure.Data.Identity;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;

namespace BookingService.Tests
{
    public class UserServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp=>dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository,ApplicationDbRepository>()
                .AddSingleton<IUserService,UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void TestGetUserById()
        {
            var service = serviceProvider.GetService<IUserService>();
            Assert.DoesNotThrowAsync(async () =>await service.GetUserById("string"));
        }

        [Test]
        public void TestGetUsersList()
        {
            var service = serviceProvider.GetService<IUserService>();
            Assert.DoesNotThrowAsync(async () => await service.GetUsersList());
        }

        [Test]
        public void TestGetUserForEdit()
        {
            var service = serviceProvider.GetService<IUserService>();
            Assert.ThrowsAsync<System.NullReferenceException>(async () => await service.GetUserForEdit("string"));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var user = new ApplicationUser()
            {
                Name = "Test",
                Email = "test@mail.com",
                UserName = "test@mail.com"
            };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();
        }
    }
}
