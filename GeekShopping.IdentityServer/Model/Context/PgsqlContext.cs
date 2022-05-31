using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class PgsqlContext : IdentityDbContext<ApplicationUser>
    {
        public PgsqlContext(DbContextOptions<PgsqlContext> options) : base(options)
        {
        }
    }
}