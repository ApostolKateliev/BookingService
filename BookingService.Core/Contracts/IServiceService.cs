using BookingService.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Contracts
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceListViewModel>> GetServicesList();

        //Task<ServiceEditViewModel> GetDetailForEdit(string id);

        //Task<bool> UpdateService(ServiceEditViewModel model);
        //Task<bool> AddService(AddServiceViewModel model);
    }
}
