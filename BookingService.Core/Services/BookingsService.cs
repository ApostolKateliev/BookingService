using BookingService.Core.Contracts;
using BookingService.Core.Models.Booking;
using BookingService.Core.Models.Service;
using BookingService.Infrastructure.Data.DataModels;
using BookingService.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BookingService.Core.Services
{
    public class BookingsService : IBookingsService
    {

        private readonly IApplicationDbRepository repo;
        

        public BookingsService(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public async Task AddBooking(AddBookingViewModel model)
        {
            try
            {
                var service = await repo.GetByIdAsync<Service>(Guid.Parse(model.ServiceId));
                var isDateParsed = DateTime.TryParseExact(
                    model.Date,
                    "MM/dd/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime parsedDate);
                
                if (isDateParsed)
                {
                    var date = parsedDate.ToString("dd/MM/yyyy");
                    var newBooking = new Booking()
                    {
                        ContactName = model.NameOfUser,
                        ContactPhoneNumber = model.PhoneForContact,
                        SpecialRequest = model.SpecialRequest,
                        Date = DateTime.Parse(date),
                        Service = service
                    };

                    await repo.AddAsync<Booking>(newBooking);
                    await repo.SaveChangesAsync();
                }
            }
            catch (Exception ae)
            {

                throw new Exception("Booking wasn`t created!");
            }
        }


        public async Task<EditBookingViewModel> GetBookingForEdit(string id)
        {
            var booking = await repo.GetByIdAsync<Booking>(Guid.Parse(id));
            return new EditBookingViewModel()
            {
                Id = booking.Id.ToString(),
                Date = booking.Date.ToString(),
                Service = booking.Service.Name,
                SpecialRequest = booking.SpecialRequest
            };
        }

        public async Task<IEnumerable<BookingListViewModel>> GetBookingsList()
        {
            return await repo.All<Booking>()
                .Select(b => new BookingListViewModel()
                {
                    Date = b.Date.ToString(),
                    ContactName = b.ContactName,
                    ContactPhoneNumber = b.ContactPhoneNumber,
                    Service = b.Service.Name,
                    SpecialRequest = b.SpecialRequest
                })
                .ToListAsync();
        }

        public  List<ServiceListViewModel> ServicesList()
        {
            var servicesList =  repo.All<Service>().Select(s => new ServiceListViewModel
            {
                Name = s.Name,
                Id = s.Id.ToString()
            }).ToList();

            return servicesList;
        }

        public async Task<bool> UpdateBookingEdit(EditBookingViewModel model)
        {
            bool result = false;

            var booking = await repo.GetByIdAsync<Booking>(Guid.Parse(model.Id));
            var bookingDate = booking.Date.ToString();
            if (booking != null)
            {
                
                bookingDate = model.Date;
                booking.Service.Name = model.Service;
                booking.SpecialRequest = model.SpecialRequest;
                await repo.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        
    }
}
