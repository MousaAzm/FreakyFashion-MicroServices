namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class ReadOrderDto
    {
        public Guid OrderId { get; set; }

        public string? Identifier { get; set; }

        public string? Customer { get; set; }

        public string? Date { get; set; }
    }
}
