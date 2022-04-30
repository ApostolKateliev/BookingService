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
    public class PostServiceTests
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
                .AddSingleton<IPostService, PostService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }



        [Test]
        public void TestGetPostsList()
        {
            var service = serviceProvider.GetService<IPostService>();
            Assert.DoesNotThrowAsync(async () => await service.GetPostList());
        }

        [Test]
        public void TestGetProductForEdit()
        {
            var service = serviceProvider.GetService<IPostService>();
            Assert.ThrowsAsync<System.FormatException>(async () => await service.GetPostForEdit("string"));
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var user = new Post()
            {
                Title = "Test",
                Body = "Test body"
            };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();
        }
    }
}
