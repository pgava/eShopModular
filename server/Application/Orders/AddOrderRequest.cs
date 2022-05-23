namespace eShopCmc.Application.Orders
{
    public class AddOrderRequest
    {
        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public List<ShoppingCart> Products { get; set; }
    }
}
