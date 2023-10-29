using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    public class DryCatFood : CatFood , UILogic <DryCatFood>
    {
        [JsonInclude]
        public double WeightPounds { get; set; }
        
        public static DryCatFood CreateProduct()
        {
            DryCatFood dryCatFood = new DryCatFood();
            Console.WriteLine("What is the name of the cat food?");
            dryCatFood.Name = Console.ReadLine();
            Console.WriteLine("Using numerical digits and decimal points only, what is the price of the cat food?");
            dryCatFood.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Using whole numbers only, what is the quantity of the cat food?");
            dryCatFood.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Using numerical digits and decimal points only, how many pounds does the cat food weigh?");
            dryCatFood.WeightPounds = double.Parse(Console.ReadLine());
            Console.WriteLine("Is the cat food kitten food? True or false response only.");
            dryCatFood.KittenFood = bool.Parse(Console.ReadLine().ToLower());
            Console.WriteLine("Type a description for your cat food.");
            dryCatFood.Description = Console.ReadLine();
            Console.WriteLine("New cat food added! " + dryCatFood.Name + " weighs " + dryCatFood.WeightPounds + " pounds. It costs " + dryCatFood.Price + " for a quantity of " + dryCatFood.Quantity + " and is set to " + dryCatFood.KittenFood + " for kitten food. The description displayed for the product will be: " + dryCatFood.Description);
            return dryCatFood;
        }
    }
}
