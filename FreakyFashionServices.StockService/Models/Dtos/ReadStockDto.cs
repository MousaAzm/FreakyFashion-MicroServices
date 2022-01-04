namespace FreakyFashionServices.StockService.Models.Dtos
{
    public class ReadStockDto
    {
        public string? ArticleNumber { get; set; }

        public int StockLevel { get; set; }
    }
}
