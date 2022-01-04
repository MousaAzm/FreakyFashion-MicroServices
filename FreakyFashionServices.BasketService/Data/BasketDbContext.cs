using FreakyFashionServices.BasketService.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.BasketService.Data
{
    
    public class BasketDbContext : DbContext
    {

        public BasketDbContext(DbContextOptions<BasketDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

    }
}
