namespace FreakyFashionServices.OrderProcessor.Models.Dtos
{
    public class CreateOrderDto
    {
        public string Identifier { get; set; } = "";

        public string Customer { get; set; } = "";

        public string Date { get; set; } = "";
    }
}
