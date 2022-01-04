using FreakyFashionServices.StockService.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.StockService.Data
{
    public class StockDbContext : DbContext
    {
        public StockDbContext(DbContextOptions<StockDbContext> options) : base(options)
        {

        }

        public DbSet<Stock> Stocks { get; set; } = null!;
    }
}
