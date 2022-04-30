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
    public class ProductServiceTests
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
                .AddSingleton<IProductService, ProductService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        

        [Test]
        public void TestGetProductsList()
        {
            var service = serviceProvider.GetService<IProductService>();
            Assert.DoesNotThrowAsync(async () => await service.GetProductsList());
        }

        [Test]
        public void TestGetProductForEdit()
        {
            var service = serviceProvider.GetService<IProductService>();
            Assert.ThrowsAsync<System.FormatException>(async () => await service.GetProductForEdit("string"));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var user = new Product()
            {
                Name = "Test",
                Description = "Test description"
            };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();
        }
    }
}
