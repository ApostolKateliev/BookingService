using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models.User
{
    public class UserRoleViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string[] Roles { get; set; }
    }
}
