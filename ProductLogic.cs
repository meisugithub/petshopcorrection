using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore
{
    public class ProductLogic : IProductLogic
    {
        //create a private variable of type List
        private List<Product> _products;

        //variables of type Dictionary to hold specific types of products
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        //create a constructor
        public ProductLogic()
        {
            _products = InitProducts();
            _catFood = new Dictionary<string, CatFood>();
            _dogLeash = new Dictionary<string, DogLeash>();
            
        }
        
            
        // create a method to add the product's dictionary            
         public void AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    throw new Exception("Null object.");
                }
                
                
                if (product is DogLeash)
                {
                    _dogLeash.Add(product.Name, product as DogLeash);
                }

                if (product is CatFood)
                {
                    _catFood.Add(product.Name, product as CatFood);
                }

                _products.Add(product);

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }   
            //finally {}
        }

        //return a list of products
        public List<Product> GetAllProducts()
        {
            return _products; 
        }

        //return catfood product
        public Product GetCatFoodByName(string name)
        {
            _catFood.TryGetValue(name, out var catFood);
            if (catFood == null)
            {
                Console.WriteLine($"catFood {name} do not exist.");
            }
            return catFood;
        }

        public List<string> GetOnlyInStockProducts()
            {
              return _products.Where(x => x.Quantity > 0).Select(x => x.Name).ToList();
            }


        private List<Product> InitProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Small Grounds",
                    Price = 1.00m,
                    Description = "It's top seller",
                    Quantity = 0,
                },
                new Product
                {
                    Name = "Cookies",
                    Price = 3.00m,
                    Description = "For the pup",
                    Quantity = 5,
                },
                new Product
                {
                    Name = "Mouse Toy",
                    Price = 5.00m,
                    Description = "Toy for Mr. Whiskers",
                    Quantity = 10,
                },
                new Product
                {
                    Name = "Cat Litter Scoop",
                    Price = 10.00m,
                    Description = "Yet another top seller",
                    Quantity = 50,
                },
            };

        }


       

    }
}
