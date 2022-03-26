using BookingService.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ServiceType Type { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
