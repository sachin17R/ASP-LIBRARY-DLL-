using System.Collections.Generic;
using System.Linq;

namespace ProductLib
{
    public interface IDbcomponents
    {
        void AddProduct(Product pro);
        void UpdateProduct(Product pro);
        void removeProduct(int id);
        List<Product> GetAllProduct();
    }

    public static class ProductFactory
    {
      public static IDbcomponents GetComponents() => new DbProduct();
    }
      class DbProduct : IDbcomponents
    {
        static Entities context = new Entities();
        public void AddProduct(Product pro)
        {
            context.Products.Add(pro);
            context.SaveChanges();
        }

        public List<Product> GetAllProduct()
        {
           return context.Products.ToList();
        }

        public void removeProduct(int id)
        {
            var found = context.Products.FirstOrDefault((p) => p.ProductId == id);
            context.Products.Remove(found);
            context.SaveChanges();
        }

        public void UpdateProduct(Product pro)
        {
            var found = context.Products.First((p) => p.ProductId == pro.ProductId);
            found.ProductImage = pro.ProductImage;
            found.ProductName = pro.ProductName;
            found.Price = pro.Price;
            found.Quantity = pro.Quantity;
            context.SaveChanges();
        }
    }
    
}
