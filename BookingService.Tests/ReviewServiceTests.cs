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
    public class ReviewServiceTests
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
                .AddSingleton<IReviewService, ReviewService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        

        [Test]
        public void TestGetReviewsList()
        {
            var service = serviceProvider.GetService<IReviewService>();
            Assert.DoesNotThrowAsync(async () => await service.GetReviewsList());
        }

        

        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var review = new Review()
            {
                Name = "Test",
                Body = "Review body"
            };
            await repo.AddAsync(review);
            await repo.SaveChangesAsync();
        }
    }
}
