using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Planets.Website.Models;

namespace Planets.WebAPI.Proxy
{
    public class PlanetsProxy
    {
        static string baseAddress = "http://localhost:8282/";

        public static async Task<bool> Test()
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                var response = client.GetAsync("api/asteroids/test").Result;

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        try
                        {
                            return JsonConvert.DeserializeObject<bool>(data);
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                    }
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<DashboardPageData> GetAsteroids(string planet, DateTime start_date, DateTime end_date, string key)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var body = new StringContent(JsonConvert.SerializeObject(new { planet = planet, start_date = start_date, end_date = end_date, api_key = key }), Encoding.UTF8, "application/json");

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
