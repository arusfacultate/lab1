using System.Linq;

namespace lab1_web_api.Models
{
    public class ProductsDbSeeder
    {
        public static void Initialize(ProductsDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Name = "Wine",
                    Description = "White, Yellow",
                    Category = "Drinks",
                    Price = 25.2
                },
                new Product
                {
                    Name = "Coca",
                    Description = "Black, Cola",
                    Category = "Drinks",
                    Price = 2.2
                }
            );
            context.SaveChanges();
        }
    }
}