using Microsoft.EntityFrameworkCore;

namespace DescontroladaAPI.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
        
        public DbSet<ProductModel> Products { get; set; }
    }
}
