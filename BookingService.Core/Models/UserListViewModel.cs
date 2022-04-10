using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        public string Name { get; set; }

        
    }
}
