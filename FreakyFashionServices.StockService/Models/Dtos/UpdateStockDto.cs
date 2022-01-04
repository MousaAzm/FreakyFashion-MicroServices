namespace FreakyFashionServices.StockService.Models.Dtos
{
    public class UpdateStockDto
    {
        
        public string? ArticleNumber { get; set; }

        public int StockLevel { get; set; }
    }
}
