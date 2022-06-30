﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Planets.WebAPI.Model
{
    public class Asteroid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public decimal Price{ get; set; }
    }
}