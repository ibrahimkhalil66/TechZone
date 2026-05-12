using System.Data.Entity;

namespace Ecom1.Models
{
    public class eshopContext: DbContext
    {
        public eshopContext(): base("name = Ecom_db") {}
        public DbSet<Product> Products { get; set; }
    }
}
