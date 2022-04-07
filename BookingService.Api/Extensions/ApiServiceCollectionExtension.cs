using BookingService.Core.Contracts;
using BookingService.Core.Services;
using BookingService.Infrastructure.Data;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookingService.Api.Extensions
{
    public static class ApiServiceCollectionExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
          
            services.AddScoped<IApplicationDbRepository, ApplicationDbRepository>();
            services.AddScoped<IUserBookingService, UserBookingService>();

            return services;
        }

        public static IServiceCollection AddApiDbContexts(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }
    }
}
