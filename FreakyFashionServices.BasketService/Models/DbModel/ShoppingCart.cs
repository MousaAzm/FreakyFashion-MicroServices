namespace FreakyFashionServices.BasketService.Models.DbModel
{
    public class ShoppingCart
    {
        public string? Identifier { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart(string identifier)
        {
            Identifier = identifier;
        }
        
    }
}

