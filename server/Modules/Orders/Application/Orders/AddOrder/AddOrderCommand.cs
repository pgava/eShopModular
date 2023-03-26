using System.Text.Json.Serialization;
using EShopModular.Modules.Orders.Application.Contracts;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

public class AddOrderCommand : CommandBase<Guid>
{
    [JsonConstructor]
    public AddOrderCommand(
        Guid id,
        string currency,
        decimal exchangeRate,
        decimal shippingCost,
        decimal totalCost,
        List<OrderItemDto> orderItems)
        : base(id)
    {
        Currency = currency;
        ExchangeRate = exchangeRate;
        ShippingCost = shippingCost;
        TotalCost = totalCost;
        OrderItems = orderItems;
    }

    public decimal ShippingCost { get; }

    public decimal TotalCost { get; }

    public string Currency { get; }

    public decimal ExchangeRate { get; }

    public List<OrderItemDto> OrderItems { get; }
}