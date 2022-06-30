using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Planets.Website.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Planets.WebAPI.Proxy;
using Planets.WebAPI.Proxy.Models;

namespace Planets.Website.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        IConfiguration siteConfig;

        public DashboardController(IConfiguration configuration)
        {
            siteConfig = configuration;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                return View(await PlanetsProxy.GetAsteroids("earth"));
            }
            catch (Exception)
            {
                return View(new DashboardPageData() { Message = "Fatal error! Error accessing the Planets API Endpoint." });
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
