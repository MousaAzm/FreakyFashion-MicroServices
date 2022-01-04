namespace FreakyFashionServices.BasketService.Models.DbModel
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(int quantity, decimal price, int productId, string productName)
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
