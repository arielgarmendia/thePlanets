using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Planets.Website.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

using Planets.WebAPI.Proxy;

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

        public ActionResult Index()
        {
            ViewBag.Planet = "earth";
            ViewBag.StartDate = DateTime.Today;
            ViewBag.EndDate = DateTime.Today.AddDays(7);

            return View();
        }

        public async Task<IActionResult> Search(string planet, string start_date, string end_date)
        {
            try
            {
                var culture = new System.Globalization.CultureInfo("es-ES");

                var searchResults = await PlanetsProxy.GetAsteroids(planet, DateTime.Parse(start_date, culture), DateTime.Parse(end_date, culture), Convert.ToString(siteConfig["ApiKey"]));

                return PartialView("_SearchResults", searchResults);
            }
            catch (Exception)
            {
                return PartialView("_SearchResults", new DashboardPageData() { Message = "Fatal error! Error accessing the Planets API Endpoint." });
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
