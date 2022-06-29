namespace eShopCmc.Application.Orders
{
    public class AddOrderRequest
    {
        public AddOrderRequest(decimal shippingCost, decimal totalCost, string currency, decimal exchangeRate, List<ShoppingCart> products)
        {
            ShippingCost = shippingCost;
            TotalCost = totalCost;
            Currency = currency;
            ExchangeRate = exchangeRate;
            Products = products;
        }

        public decimal ShippingCost { get; set; }
        public decimal TotalCost { get; set; }
        public string Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public List<ShoppingCart> Products { get; set; }
    }
}
