using BookingService.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Data.DataModels
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        public TimeSpan Duration { get; set; }

        [Required]
        [ForeignKey(nameof(CarDetail))]
        public int CarDetailId { get; set; }
        public CarDetail CarDetail { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }
    }
}
