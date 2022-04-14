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

        //Task<ServiceEditViewModel> GetDetailForEdit(int id);

        //Task<bool> UpdateDetail(ServiceEditViewModel model);
        //Task<bool> AddDetail(AddServiceViewModel model);
    }
}
