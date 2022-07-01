using System;
using System.Collections.Generic;
using System.Linq;

namespace Planets.WebAPI.Model
{
    public class SearchParams
    {
        public string planet { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; } 
        public string api_key { get; set; }
    }
}