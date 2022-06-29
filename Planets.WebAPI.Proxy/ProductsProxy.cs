using Inventory.WebAPI.Proxy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.WebAPI.Proxy
{
    public class ProductsProxy
    {
        static string baseAddress = "https://theinventorywebapi.travelgosystems.net/";//"http://localhost:61889/";//;

        public static async Task<bool> SendProducts(List<Product> products)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var body = new StringContent(JsonConvert.SerializeObject(products), Encoding.UTF8, "application/json");

            var resp2 = client.PostAsync("api/products", body).Result;

            resp2.EnsureSuccessStatusCode();

            var ss = await resp2.Content.ReadAsStringAsync();

            return resp2.IsSuccessStatusCode;
        }

        public static async Task<bool> SendProduct(Product product)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var body = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var resp2 = client.PostAsync("api/products/insert", body).Result;

            resp2.EnsureSuccessStatusCode();

            var ss = await resp2.Content.ReadAsStringAsync();

            return resp2.IsSuccessStatusCode;
        }

        public static async Task<List<Product>> GetProducts()
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                var response = await client.GetAsync("api/products/all");

                //Direct Get without JSon's DeserializeObject
                List<Product> products = await response.Content.ReadAsAsync<List<Product>>();

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        try
                        {
                            return JsonConvert.DeserializeObject<List<Product>>(data);
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
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<Product> GetProduct(string name)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(baseAddress);

                var response = await client.GetAsync("api/products/" + WebUtility.HtmlEncode(name));

                //Direct Get without JSon's DeserializeObject
                Product product = await response.Content.ReadAsAsync<Product>();

                if (response.IsSuccessStatusCode)
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();

                        try
                        {
                            return JsonConvert.DeserializeObject<Product>(data);
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
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<bool> DeleteProduct(string name)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(baseAddress);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var body = new StringContent("", Encoding.UTF8, "application/json");

            var resp2 = client.PostAsync("api/products/delete/" + WebUtility.HtmlEncode(name), body).Result;

            resp2.EnsureSuccessStatusCode();

            var ss = await resp2.Content.ReadAsStringAsync();

            return resp2.IsSuccessStatusCode;
        }
    }
}
