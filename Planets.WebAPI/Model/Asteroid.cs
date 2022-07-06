using System;
using System.Collections.Generic;
using System.Linq;

namespace Planets.WebAPI.Model
{
    public class Asteroid
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Diameter { get; set; }
        public double Velocity { get; set; }
        public string Planet { get; set; }
    }
}