using System.Data.Entity;

namespace Ecom1.Models
{
    public class eshopInitializer: DropCreateDatabaseIfModelChanges<eshopContext>
    {
        protected override void Seed(eshopContext context)
        {
            var productsList = new List<Product>
            {
                new Product { NameProduct = "Laptop",Quantity = 20 , PriceProduct = 20000, Description = "Good" },
                new Product { NameProduct = "Smartphone", Quantity = 50, PriceProduct = 10000, Description = "Excellent" },
                new Product { NameProduct = "Headphones", Quantity = 30, PriceProduct = 15000, Description = "High Quality" }
            };
            productsList.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
