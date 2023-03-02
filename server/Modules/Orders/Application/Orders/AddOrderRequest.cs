namespace eShopModular.Modules.Orders.Application.Orders
{
    public class AddOrderRequest
    {
        public AddOrderRequest(decimal shippingCost, decimal totalCost, string currency, decimal exchangeRate, List<ShoppingCart2> products)
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
        public List<ShoppingCart2> Products { get; set; }
    }
}
