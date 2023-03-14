#nullable disable
using EShopModular.Common.Domain;
using EShopModular.Modules.Orders.Domain.Orders.Events;
using EShopModular.Modules.Orders.Domain.Orders.Rules;

namespace EShopModular.Modules.Orders.Domain.Orders;

public class Order : Entity, IAggregateRoot
{
    public Order(OrderId id, string currency, List<OrderItem> orderItems, decimal shippingCost, decimal totalCost, decimal exchangeRate, DateTime createDate)
    {
        CheckRule(new OrderCurrencyMustBeValidRule(currency));

        Id = id;
        Currency = currency;
        OrderItems = orderItems;
        ShippingCost = shippingCost;
        TotalCost = totalCost;
        ExchangeRate = exchangeRate;
        CreateDate = createDate;

        AddDomainEvent(new OrderCreatedDomainEvent(Id));
    }

    public Order()
    {
    }

    public OrderId Id { get; set; }

    public decimal ShippingCost { get; set; }

    public decimal TotalCost { get; set; }

    public string Currency { get; set; }

    public decimal ExchangeRate { get; set; }

    public DateTime CreateDate { get; set; }

    public List<OrderItem> OrderItems { get; set; }
}
#nullable enable