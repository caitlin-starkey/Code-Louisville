using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    public class DogLeash : Product 
    {
        [JsonInclude]
        public int LengthInches { get; set; }
        [JsonInclude]
        public string Material { get; set; }
        public static DogLeash CreateProduct()
        {
            DogLeash dogLeash = new DogLeash();
            Console.WriteLine("What is the name of the dog leash?");
            dogLeash.Name = Console.ReadLine();
            Console.WriteLine("Using numerical digits and decimal points only, what is the price of the dog leash?");
            dogLeash.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Using numerical digits only, how many inches long is the leash?");
            dogLeash.LengthInches = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the dog leash made of?");
            dogLeash.Material = Console.ReadLine();
            Console.WriteLine("Type a description for your dog leash.");
            dogLeash.Description = Console.ReadLine();
            Console.WriteLine("New dog leash added! " + dogLeash.Name + " costs " + dogLeash.Price + " and is " + dogLeash.LengthInches + " inches long. It is made of " + dogLeash.Material + ". The description displayed for the product will be: " + dogLeash.Description);
            return dogLeash;
        }

    }
}
