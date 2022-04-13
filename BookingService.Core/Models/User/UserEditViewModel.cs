using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models.User
{
    public class UserEditViewModel
    {
        public string? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [StringLength(10)]
        public string? PhoneNumber { get; set; }
    }
}
