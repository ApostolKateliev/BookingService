﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class EditComponentViewModel
    {
        public string Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Specification { get; set; }
    }
}