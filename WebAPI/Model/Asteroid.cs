using System;
using System.Collections.Generic;
using System.Linq;

namespace Planets.WebAPI.Model
{
    public class Asteroid
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Diameter { get; set; }
        public decimal Velocity { get; set; }
        public string Planet { get; set; }
    }
}