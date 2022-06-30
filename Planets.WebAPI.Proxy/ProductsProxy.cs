using Newtonsoft.Json;
using Planets.WebAPI.Proxy.Models;
using Planets.Website.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planets.WebAPI.Proxy
{
    public class PlanetsProxy
    {
        static string baseAddress = "http://localhost:61889//";

        public static async Task<DashboardPageData> GetAsteroids(string planet)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var body = new StringContent(JsonConvert.SerializeObject(new { Name = planet }), Encoding.UTF8, "application/json");

                var response = client.PostAsync("api/asteroids/", body).Result;

                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        try
                        {
                            return JsonConvert.DeserializeObject<DashboardPageData>(data);
                        }
                        catch (Exception)
                        {
                            return null;
                        }
                    }
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
