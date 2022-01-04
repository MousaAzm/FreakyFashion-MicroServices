using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.CatalogService.Models.DbModel
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? ArticleNumber { get; set; }
        [Required]
        public string? UrlSlug { get; set; }
    }
}
