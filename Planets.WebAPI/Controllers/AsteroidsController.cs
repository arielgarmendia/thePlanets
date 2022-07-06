using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Planets.WebAPI.Model;

namespace Planets.WebAPI.Controllers
{
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private string baseAddress = "https://api.nasa.gov/neo/rest/v1/feed";

        public AsteroidsController()
        {
        }

        // GET api/asteroids/}
        [HttpGet]
        [Route("api/asteroids/test")]
        public bool Test()
        {
            return true;
        }

        // POST => GET api/asteroids/}
        [HttpPost]
        [Route("api/asteroids/")]
        public async Task<JsonResult> Get([FromBody] JToken jsonbody)
        {
            List<Asteroid> asteroids = new List<Asteroid>();

            SearchParams parameter = JsonConvert.DeserializeObject<SearchParams>(jsonbody.ToString());

            if (parameter.planet == "")
                return new JsonResult(new { Message = "You must specifie a target planet.", Result = asteroids });

            try
            {
                //get from NASA api here

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                var response = client.GetAsync("?start_date=" + parameter.start_date.ToString("yyyy-MM-dd") + "&end_date=" + parameter.end_date.ToString("yyyy-MM-dd") + "&api_key=" + parameter.api_key).Result;

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        try
                        {
                            var jsonAsteroids = JsonConvert.DeserializeObject<JSONAsteroids>(data);

                            if (jsonAsteroids.near_earth_objects != null)
                            {
                                foreach (var token in jsonAsteroids.near_earth_objects.Children())
                                {
                                    var nasaNearEarthDatesAsteroids = JsonConvert.DeserializeObject<List<NasaAsteroid>>((token as Newtonsoft.Json.Linq.JProperty).Value.ToString());

                                    if (nasaNearEarthDatesAsteroids != null && nasaNearEarthDatesAsteroids.Any())
                                    {
                                        foreach (var nasaAsteroids in nasaNearEarthDatesAsteroids)
                                        {
                                            if (nasaAsteroids.is_potentially_hazardous_asteroid)
                                            {
                                                var newAsteroid = new Asteroid()
                                                {
                                                    Name = nasaAsteroids.name,
                                                    Planet = nasaAsteroids.close_approach_data.FirstOrDefault().orbiting_body,
                                                    Date = Convert.ToDateTime(nasaAsteroids.close_approach_data.FirstOrDefault().close_approach_date),
                                                    Diameter = (nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_max - nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_min) == 0 ? nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_max : (nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_min + ((nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_max - nasaAsteroids.estimated_diameter.kilometers.estimated_diameter_min) / 2)),
                                                    Velocity = Convert.ToDouble(nasaAsteroids.close_approach_data.FirstOrDefault().relative_velocity.kilometers_per_hour)
                                                };

                                                asteroids.Add(newAsteroid);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                                return new JsonResult(new { Message = "No asteroids were found matching the search criteria. Please tsry a different combination of parameters.", Result = asteroids });
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    var result = new JsonResult(new { Message = "The server failed to process this request. Please verify source data is compatible.", Result = asteroids });

                    return result;
                }
            }
            catch (Exception)
            {
                var result = new JsonResult(new { Message = "The server failed to process this request. Please verify source data is compatible.", Result = asteroids });

                return result;
            }

            return new JsonResult(new { Message = "", Result = asteroids });
        }
    }
}
