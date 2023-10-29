using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Pet_Store
{
    internal interface IProductLogic
    {
        public void AddProduct(Product product);
        public List<Product> GetAllProducts();
        public Dictionary<string, DogLeash> GetAllLeashes();
        public Dictionary<string, CatFood> GetAllFoods();
        public DogLeash GetDogLeashByName(string Name);
        public CatFood GetCatFoodByName(string Name);
        public List<Product> GetOnlyInStockProducts();
        public decimal GetTotalPriceOfInventory();
        public T GetProductByName<T>(string name) where T : Product;
    }
}
