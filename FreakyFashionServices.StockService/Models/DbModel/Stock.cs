using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.StockService.Models.DbModel
{
    public class Stock
    {
        [Key]
        public string? ArticleNumber { get; set; }

        public int StockLevel { get; set; }
    }
}
