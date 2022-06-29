using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.WebAPI.Model
{
    public class Product : BaseProduct
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public decimal Price{ get; set; }

        public Product() : base() { }

        public int Insert(Product product)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    connection.Insert(product);

                    return product.Id;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return -1;
            }
        }
        public List<Product> SelectAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    return connection.Table<Product>().ToList();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return null;
            }
        }
        public bool Update(Product product, bool useName = false)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    if (!useName)
                        connection.Query<Product>("UPDATE Product set Name=?, InsertionDate=?, ExpiryDate=? Where Id=?", product.Name, product.InsertionDate, product.ExpiryDate, product.Id);
                    else
                        connection.Query<Product>("UPDATE Product set Name=?, InsertionDate=?, ExpiryDate=? Where Name=?", product.Name, product.InsertionDate, product.ExpiryDate, product.Name);

                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }
        public bool Delete(Product product)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    connection.Delete(product);

                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }
        public bool Delete(string product)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    connection.Delete(Select(product));

                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }
        public bool DeleteAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    var products = SelectAll();

                    foreach (var product in products)
                        connection.Delete(product);

                    return true;
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return false;
            }
        }
        public Product Select(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    return connection.Query<Product>("SELECT * FROM Product Where Id=?", Id).FirstOrDefault();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return null;
            }
        }
        public Product Select(string Name)
        {
            try
            {
                using (var connection = new SQLiteConnection(database_file))
                {
                    return connection.Query<Product>("SELECT * FROM Product Where Name=?", Name).FirstOrDefault();
                }
            }
            catch (SQLite.SQLiteException ex)
            {
                return null;
            }
        }
    }
}