using FreakyFashionServices.CatalogService.Models.DbModel;

namespace FreakyFashionServices.CatalogService.Data
{
    public static class Seeding
    {
        public static void CreateDbIfNotExists(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();                        
            var context = scope.ServiceProvider.GetService<CatalogDbContext>();
            if (context != null) SeedData(scope.ServiceProvider.GetService<CatalogDbContext>() ?? throw new InvalidOperationException());
        }

        public static void SeedData(CatalogDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Products.AddRange(
             new Product { Name = "Product 01", Description = "Lorem Ipsum is simply.", ImageUrl = "../images/img01.jpg", Price = 475, ArticleNumber= "ABC546", UrlSlug = "product-01"},
             new Product { Name = "Product 02", Description = "Lorem Ipsum is simply.", ImageUrl = "../images/img02.jpg", Price = 815, ArticleNumber = "DFG636", UrlSlug = "product-02"}
             );

            context.SaveChanges();         
        }
    }
}
