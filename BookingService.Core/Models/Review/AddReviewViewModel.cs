using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models.Review
{
    public class AddReviewViewModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]

        public string? Name { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "{0} must be between {2} and {1} characters")]

        public string? Body { get; set; }
    }
}
