using FreakyFashionServices.StockService.Models.DbModel;

namespace FreakyFashionServices.StockService.Data
{
    public static class Seeding
    {
        public static void CreateDbIfNotExists(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<StockDbContext>();
            if (context != null) SeedData(scope.ServiceProvider.GetService<StockDbContext>() ?? throw new InvalidOperationException());
        }

        public static void SeedData(StockDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Stocks.AddRange(
             new Stock { ArticleNumber = "ABC546", StockLevel = 16 },
             new Stock { ArticleNumber = "DFG636", StockLevel = 20 }
             );

            context.SaveChanges();
        }
    }
}
