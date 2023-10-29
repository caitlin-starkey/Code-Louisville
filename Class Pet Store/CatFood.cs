using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    public class CatFood : Product, UILogic<CatFood>
    {
        [JsonInclude]
        public bool KittenFood { get; set; }

        public static CatFood CreateProduct()
        {
            CatFood catFood = new CatFood();
            Console.WriteLine("What is the name of the cat food?");
            catFood.Name = Console.ReadLine();
            Console.WriteLine("Using numerical digits and decimal points only, what is the price of the cat food?");
            catFood.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Using whole numbers only, what is the quantity of the cat food?");
            catFood.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Is the cat food kitten food? True or false response only.");
            catFood.KittenFood = bool.Parse(Console.ReadLine().ToLower());
            Console.WriteLine("Type a description for your cat food.");
            catFood.Description = Console.ReadLine();
            Console.WriteLine("New cat food added! " + catFood.Name + " costs " + catFood.Price + " for a quantity of " + catFood.Quantity + " and is set to " + catFood.KittenFood + " for kitten food. The description displayed for the product will be: " + catFood.Description);
            return catFood;
        }
    }
}
