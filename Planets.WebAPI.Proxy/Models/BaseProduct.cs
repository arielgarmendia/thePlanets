using Newtonsoft.Json;

namespace Planets.WebAPI.Proxy.Models
{
    public class BaseProduct
    {
        [JsonIgnore]
        public string database_file = "";

        public BaseProduct()
        {
        }
    }
}