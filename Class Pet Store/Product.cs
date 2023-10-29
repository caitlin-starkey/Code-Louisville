using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    public class Product : UILogic<Product>
    {
        [JsonInclude]
        public string Name { get; set; }
        [JsonInclude]
        public decimal Price { get; set; }
        [JsonInclude]
        public int Quantity { get; set; }
        [JsonInclude]
        public string Description { get; set; }

        public static Product CreateProduct()
        {
            Product product = new Product();
            Console.WriteLine("What is the name of the product?");
            product.Name = Console.ReadLine();
            Console.WriteLine("Using numerical digits and decimal points only, what is the price of the product?");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Using whole numbers only, what is the quantity of the product?");
            product.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Type a description for your product.");
            product.Description = Console.ReadLine();
            Console.WriteLine("New product added! " + product.Name + " costs " + product.Price + " for a quantity of " + product.Quantity + " . The description displayed for the product will be: " + product.Description);
            return product;
        }
    }
}
