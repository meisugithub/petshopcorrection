
using System.Text.Json;
using System;
using PetStore;
using System.Runtime.CompilerServices;



namespace PetStore
{
    internal class Program
    {

        private static void InStockProducts(ProductLogic productLogic)
        {
            Console.WriteLine("Current In-Stock Products\n");

            foreach (var item in productLogic.GetOnlyInStockProducts())
            {
                Console.WriteLine("\t" + item);
            }
        }


        static void Main(string[] args)
        {
            //create an instance of new ProductLogic
            var productLogic = new ProductLogic();

            string userInput;


            do
            {
                Console.WriteLine("Press 1 to add a cat food product");
                Console.WriteLine("Press 2 to view a cat food product by name");
                Console.WriteLine("Press 0 to disply in-stock products");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    // create a new CatFood object
                    CatFood catFood = new CatFood();

                    //add a product
                    Console.WriteLine("Enter Product Name:");
                    catFood.Name = Console.ReadLine();
                    Console.WriteLine("Enter price:");
                    catFood.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter quantity");
                    catFood.Quantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter description");
                    catFood.Description = Console.ReadLine();
                    Console.WriteLine("Enter weight pounds");
                    catFood.WeightPounds = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("If the product is kitten food, enter true.  Otherwise enter false.");
                    catFood.KittenFood = Convert.ToBoolean(Console.ReadLine());

                    //take the entered product and store it in the ProductLogic's internal products list
                    productLogic.AddProduct(catFood);
                    Console.WriteLine("The product has been added!");

                    string jsonString = JsonSerializer.Serialize(catFood);
                    Console.WriteLine(jsonString);

                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Enter a Cat Food Product Name:");

                    string productLookup = Console.ReadLine();

                    var product = productLogic.GetCatFoodByName(productLookup);
                    if (product != null)
                    {
                        Console.WriteLine("We found the product.");
                        Console.WriteLine(JsonSerializer.Serialize(product));
                    }
                    else
                    {
                        Console.WriteLine("The product is not found.");
                    }

                }
                else if (userInput == "0")
                {
                    productLogic.GetOnlyInStockProducts;
                 }

                else if (userInput.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(userInput + " is not a valid command");
                    Console.WriteLine();
                }
                
                
             }while (userInput != "exit");


        }
    }
}
