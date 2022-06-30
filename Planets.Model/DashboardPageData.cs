using Planets.WebAPI.Proxy.Models;
using System;
using System.Collections.Generic;

namespace Planets.Website.Models
{
    public class DashboardPageData
    {
        public string Message { get; set; }
        public List<Asteroid> Result1 { get; set; }
        public List<Asteroid> Result2 { get; set; }
    }
}
