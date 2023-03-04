using EShopModular.Modules.Orders.Application.Contracts;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

public class AddOrderCommand : CommandBase
{
    public AddOrderCommand(
        string currency,
        decimal exchangeRate,
        decimal shippingCost,
        decimal totalCost,
        List<OrderItemDto> orderItems)
    {
        Currency = currency;
        ExchangeRate = exchangeRate;
        ShippingCost = shippingCost;
        TotalCost = totalCost;
        OrderItems = orderItems;
    }

    public decimal ShippingCost { get; set; }

    public decimal TotalCost { get; set; }

    public string Currency { get; set; }

    public decimal ExchangeRate { get; set; }

    public List<OrderItemDto> OrderItems { get; set; }
}