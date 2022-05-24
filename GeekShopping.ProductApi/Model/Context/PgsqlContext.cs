using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class PgsqlContext: DbContext
    {
        public PgsqlContext()
        {
        }
        public PgsqlContext(DbContextOptions<PgsqlContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

       
    }
}
