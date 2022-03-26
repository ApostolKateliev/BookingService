using BookingService.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ProductType Type { get; set; }

        public Specification Specification { get; set; }
    }
}
