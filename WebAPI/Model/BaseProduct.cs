using System.IO;
using Microsoft.AspNetCore.Hosting.Internal;
using Newtonsoft.Json;
using SQLite;

namespace Inventory.WebAPI.Model
{
    public class BaseProduct
    {
        [JsonIgnore]
        protected string database_file;

        [JsonIgnore]
        public string host_path
        {
            set
            {
                database_file = Path.Combine(value, "App_Data\\inventoryproducts.db3");

                CreateDatabase();
            }
        }

        public BaseProduct()
        {
        }

        private bool CreateDatabase()
        {
            try
            {
                if (!File.Exists(database_file))
                    using (var connection = new SQLiteConnection(database_file))
                    {
                        connection.CreateTable<Product>();

                        return true;
                    }
                else
                    return true;
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }
    }
}