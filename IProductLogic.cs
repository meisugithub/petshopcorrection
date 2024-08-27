namespace PetStore
{
    internal interface IProductLogic
    {
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetCatFoodByName(string name);
        
        List<string> GetOnlyInStockProducts();
    }
}
