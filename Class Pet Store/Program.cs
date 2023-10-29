// See https://aka.ms/new-console-template for more information
using Class_Pet_Store;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


var services = CreateServiceCollection();
static IServiceProvider CreateServiceCollection()
{
    return new ServiceCollection()
        .AddTransient<IProductLogic, ProductLogic>()
        .BuildServiceProvider();
}

var productLogic = services.GetService<IProductLogic>();

Console.WriteLine("Press 1 to add a product");
Console.WriteLine("Press 2 to retrieve a product");
Console.WriteLine("Press 3 to see only in stock products.");
Console.WriteLine("Press 4 to see the total value of currently in stock products.");
Console.WriteLine("Press 5 to add a product using a JSON string.");
Console.WriteLine("Type 'exit' to quit");
string userInput = Console.ReadLine();
while (userInput.ToLower() != "exit")
{
    if (userInput == "1")
    {
        Console.WriteLine("Press 1 to add a cat food; press 2 to add a dog leash.");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            Console.WriteLine("Is the cat food dry food? True or false response only.");
            string isDryFood = Console.ReadLine().ToLower();
            if (isDryFood == "true")
            { 
                productLogic.AddProduct(DryCatFood.CreateProduct());
            }
            else if (isDryFood == "false")
            {    
                productLogic.AddProduct(CatFood.CreateProduct());
            }
            else
            {
                Console.WriteLine("That input is not recognized.");
            }
        }
        else if (userInput == "2") 
        { 
            productLogic.AddProduct(DogLeash.CreateProduct());
        }
        else
        {
            Console.WriteLine("That input is not recognized.");
        }
    }
    else if (userInput == "2")
    {
        Console.WriteLine("Press 1 to see cat foods, press 2 to see dog leashes, type anything else to escape.");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            foreach (CatFood food in productLogic.GetAllFoods().Values)
                    Console.WriteLine(food.Name);
            Console.WriteLine("For which product would you like more information?");
            CatFood food2 = productLogic.GetCatFoodByName(Console.ReadLine());
            if (food2 == null)
            {
                Console.WriteLine("The product couldn't be found.");
            }
            else
            {
                Console.WriteLine(food2.Name + " costs " + food2.Price + " and there are " + food2.Quantity + " in stock. It is set to " + food2.KittenFood + " for kitten food. The description of the product is: " + food2.Description);
            }
        }
        
        else if (userInput == "2")
        {
            foreach (DogLeash leash in productLogic.GetAllLeashes().Values)
                   Console.WriteLine(leash.Name);
                   Console.WriteLine("For which product would you like more information?");
                   DogLeash leash2 = productLogic.GetDogLeashByName(Console.ReadLine());
            if (leash2 == null)
            {
                Console.WriteLine("The product couldn't be found.");
            }
            else
            {
                Console.WriteLine(leash2.Name + " costs " + leash2.Price + " and is " + leash2.LengthInches + " inches long. It is made of " + leash2.Material + ". The description of the product is: " + leash2.Description);
            }
                
        }
        else if (userInput == "3")
        {
            foreach (Product product in productLogic.GetAllProducts())
                Console.WriteLine(product.Name);
            Console.WriteLine("For which product would you like more information?");
            Product product2 = productLogic.GetProductByName<Product>(Console.ReadLine());
            if(product2 == null)
            {
                Console.WriteLine("The product couldn't be found.");
            }
            else
            {
                Console.WriteLine()
            }
        }
        else
        {
            Console.WriteLine("That input is not recognized.");
        }
 
    }
    else if (userInput == "3")
    {
        Console.WriteLine("Here is a list of in stock products.");
        foreach (Product product in productLogic.GetOnlyInStockProducts())
        {
            Console.WriteLine(product.Name);
        }
    }
    else if (userInput == "4")
    {
        Console.WriteLine(productLogic.GetTotalPriceOfInventory());
    }
    else if (userInput == "5")
    {
        Console.WriteLine("Press 1 to add a dry cat food, 2 for other forms of cat food, or 3 to add a leash.");
        userInput = Console.ReadLine();
        if (userInput == "1") 
        {
            string jsonString = Console.ReadLine();
            DryCatFood? dryCatFood =
                JsonSerializer.Deserialize<DryCatFood>(jsonString);
            productLogic.AddProduct(dryCatFood);
        }
        else if (userInput == "2") 
        {
            string jsonString = Console.ReadLine();
            CatFood? catFood =
                JsonSerializer.Deserialize<CatFood>(jsonString);
            productLogic.AddProduct(catFood);
        }
        else if (userInput == "3") 
        {
            string jsonString = Console.ReadLine();
            DogLeash? dogLeash =
                JsonSerializer.Deserialize<DogLeash>(jsonString);
            productLogic.AddProduct(dogLeash);
        }
        else
        {
            Console.WriteLine("That input is not recognized.");
        }

    }
    else
    {
        Console.WriteLine("That input is not recognized.");
    }
    Console.WriteLine("Press 1 to add a product");
    Console.WriteLine("Press 2 to retrieve a product");
    Console.WriteLine("Press 3 to see only in stock products.");
    Console.WriteLine("Press 4 to see the total value of currently in stock products.");
    Console.WriteLine("Type 'exit' to quit");
    userInput = Console.ReadLine();
}
