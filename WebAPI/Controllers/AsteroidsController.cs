using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public AsteroidsController()
        {
        }

        // GET api/asteroids/}
        [HttpPost]
        [Route("api/asteroids/")]
        public JsonResult Get([FromBody] JToken jsonbody)
        {
            List<Asteroid> asteroids = new List<Asteroid>();

            Asteroid parameter = JsonConvert.DeserializeObject<Asteroid>(jsonbody.ToString());

            if (parameter.Name == "")
                return new JsonResult(new { Message = "You must specifie a target planet.", asteroids });

            var tmp = "";

            try
            {
                //get from NASA api here
                tmp = "Will be empty.";
            }
            catch (Exception)
            {
                var result = new JsonResult(new { Message = "The server failed to process this file. Please verify source data is compatible.", asteroids });

                result.StatusCode = 500;
            }

            return new JsonResult(new { Message = tmp, asteroids });
        }
    }
}
