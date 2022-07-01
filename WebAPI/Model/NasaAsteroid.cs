using System;
using System.Collections.Generic;
using System.Linq;

namespace Planets.WebAPI.Model
{
    public class NasaNearEarthAsteroids
    { 
        public List<NasaAsteroid> near_earth_objects { get; set; }
    }

    public class NasaAsteroid
    {
        public string name { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public Diameter estimated_diameter { get; set; }
        public ApproachData close_approach_data { get; set; }
    }

    public class ApproachData
    {
        public string orbiting_body { get; set; }
        public DateTime close_approach_date { get; set; }
        public ApproachVelocity relative_velocity  { get; set; }
    }

    public class ApproachVelocity
    {
        public decimal kilometers_per_hour { get; set; }
    }

    public class Diameter
    {
        public EstimatedDiameterMinMax kilometers { get; set; }
    }

    public class EstimatedDiameterMinMax
    {
        public decimal estimated_diameter_min { get; set; }
        public decimal estimated_diameter_max { get; set; }
    }
}