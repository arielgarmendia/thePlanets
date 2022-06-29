using Newtonsoft.Json;

namespace Inventory.WebAPI.Proxy.Models
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