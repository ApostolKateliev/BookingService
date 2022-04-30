using BookingService.Core.Contracts;
using BookingService.Core.Services;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Tests
{
    public class ServicesServiceTests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IServiceService, ServiceService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        

        [Test]
        public void TestGetServicesList()
        {
            var service = serviceProvider.GetService<IServiceService>();
            Assert.DoesNotThrowAsync(async () => await service.GetServicesList());
        }

        [Test]
        public void TestGetServiceForEdit()
        {
            var service = serviceProvider.GetService<IServiceService>();
            Assert.ThrowsAsync<System.FormatException>(async () => await service.GetServiceForEdit("string"));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var service = new Service()
            {
                Description = "Test",
                Price = "60",
                Name = "Test",
                Duration = "minutes"
            };
            await repo.AddAsync(service);
            await repo.SaveChangesAsync();
        }
    }
}
