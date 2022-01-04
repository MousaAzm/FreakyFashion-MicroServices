namespace FreakyFashionServices.APIGateway.Models.Dtos
{
    public class CartItemDto
    {
        public CartItemDto(int quantity, decimal price, int productId, string productName)
        {
            Quantity = quantity;
            Price = price;
            ProductId = productId;
            ProductName = productName;
        }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
