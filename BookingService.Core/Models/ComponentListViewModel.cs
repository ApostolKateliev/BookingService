﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingService.Core.Models
{
    public class ComponentListViewModel
    {
        public string Id { get; set; }
        public string? Name { get; set; }

        public string? Specification { get; set; }
    }
}