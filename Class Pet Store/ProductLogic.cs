using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using FluentValidation;
using FluentValidation.Results;

namespace Class_Pet_Store
{
    public class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _leashes;
        private Dictionary<string, CatFood> _felineFoods;
        private Dictionary<string, DryCatFood> _dryFoods;

        public ProductLogic()
        {
            _products = new List<Product>();
            _leashes = new Dictionary<string, DogLeash>();
            _felineFoods = new Dictionary<string, CatFood>();
            _dryFoods = new Dictionary<string, DryCatFood>();

            AddProduct(new DryCatFood()
            {
                Name = "Tender Selects",
                Price = 14.99M,
                Quantity = 5,
                Description = "Balanced nutrition for typical cats.",
                KittenFood = false,
                WeightPounds = 7
            });
            AddProduct(new CatFood()
            {
                Name = "Nasty Pouch",
                Price = 1.19M,
                Quantity = 0,
                Description = "Tuna scented tubby custard.",
                KittenFood = true
            });
            AddProduct(new DogLeash()
            {
                Name = "The Accordion",
                Price = 15.78M,
                Quantity = 2,
                Description = "Hours of endless fun for you and Fido!",
                LengthInches = 20,
                Material = "nylon and elastic"
            });
        }
        public List<Product> GetOnlyInStockProducts()
        {
            return _products.InStock();
        }
        public void AddProduct(Product product)
        {
            _products.Add(product);
            ProductValidator validator = new ProductValidator();

            ValidationResult results = validator.Validate(product);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            if (product is DogLeash)
            {
                _leashes.Add(product.Name, product as DogLeash);
            }
            else if (product is CatFood)
            {
                _felineFoods.Add(product.Name, product as CatFood);
            }
            else if (product is DryCatFood)
            {
                _dryFoods.Add(product.Name, product as DryCatFood);
            }
        }
        public decimal GetTotalPriceOfInventory()
        {
            var totalPrice =
                from product in _products.InStock()
                select product.Price * product.Quantity;
            return totalPrice.Sum();
        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public Dictionary<string, DogLeash> GetAllLeashes()
        {
                return _leashes;
        }
        public Dictionary<string, CatFood> GetAllFoods()
        {
            return _felineFoods;
        }
        public T GetProductByName<T>(string name) where T : Product
        {
            if (typeof(T) == typeof(DogLeash))
            {
                return GetDogLeashByName(name) as T;
            }
            else if (typeof(T) == typeof(CatFood))
            {
                return GetCatFoodByName(name) as T;
            }
            else
            {
                return null;
            }
        }
        public DogLeash GetDogLeashByName(string Name) 
        {
            try
            {
                return _leashes[Name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public CatFood GetCatFoodByName(string Name)
        {
            try
            {
                return _felineFoods[Name];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
