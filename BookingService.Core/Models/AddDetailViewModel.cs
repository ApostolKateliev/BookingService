using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BookingService.Core.Models
{
    public class AddDetailViewModel
    {
        public int Id { get; set; }


        [Required]
        public string? Name { get; set; }

        public string? Specification { get; set; }
    }
}
