using FreakyFashionServices.CatalogService.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.CatalogService.Data
{
    public class CatalogDbContext : DbContext
    {

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

    }
}
