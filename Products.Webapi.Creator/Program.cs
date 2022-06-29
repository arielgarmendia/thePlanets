using Inventory.WebAPI.Proxy;
using Inventory.WebAPI.Proxy.Models;
using System;
using System.Collections.Generic;

namespace Products.Webapi.Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Products();
        }

        static async void Products()
        {
            try
            {
                var products = new List<Product>();

                var product1 = new Product()
                {
                    Name = "Golden Meat",
                    InsertionDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.AddDays(30),
                    Description = "",
                    Price = 2,
                    Weight = 500,
                    Type = "Canned Meat"
                };

                var product2 = new Product()
                {
                    Name = "Silver Olives",
                    InsertionDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.Subtract(new TimeSpan(30, 0, 0, 0, 0)),
                    Description = "",
                    Price = 2,
                    Weight = 200,
                    Type = "Olives"
                };

                var product3 = new Product()
                {
                    Name = "Silver Meat",
                    InsertionDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.AddDays(30),
                    Description = "",
                    Price = 2,
                    Weight = 500,
                    Type = "Canned Meat"
                };

                var product4 = new Product()
                {
                    Name = "Golden Olives",
                    InsertionDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.Subtract(new TimeSpan(30, 0, 0, 0, 0)),
                    Description = "",
                    Price = 2,
                    Weight = 200,
                    Type = "Olives"
                };

                var product5 = new Product()
                {
                    Name = "Golden Anchovies",
                    InsertionDate = DateTime.Today,
                    ExpiryDate = DateTime.Today.Subtract(new TimeSpan(30, 0, 0, 0, 0)),
                    Description = "",
                    Price = 12,
                    Weight = 500,
                    Type = "Anchovies"
                };

                products.Add(product1);
                products.Add(product2);
                products.Add(product3);
                products.Add(product4);

                var got_products = await ProductsProxy.GetProducts();

                foreach (var item in got_products)
                    Console.WriteLine("retrieved products: " + item.Name);

                //foreach (var item in got_products)
                //    await ProductsProxy.DeleteProduct(item.Name);

                var result = await ProductsProxy.SendProducts(products);

                //Console.WriteLine("sending products result: " + result);

                List<Product> singleProduct = new List<Product>();

                singleProduct.Add(product5);

                result = await ProductsProxy.SendProducts(singleProduct);

                Console.WriteLine("sending single product result: " + result);

                got_products = await ProductsProxy.GetProducts();

                foreach (var item in got_products)
                    Console.WriteLine("retrieved products: " + item.Name);

                var singleProduct2 = await ProductsProxy.GetProduct("Silver Olives");

                if (singleProduct2 != null)
                    Console.WriteLine("retrieved single product: " + singleProduct2.Name);
                else
                    Console.WriteLine("product was not found in inventory");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

                Console.ReadKey();
            }
        }
    }
}
