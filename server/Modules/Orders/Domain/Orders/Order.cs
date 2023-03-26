#nullable disable
using EShopModular.Common.Domain;
using EShopModular.Modules.Orders.Domain.Orders.Events;
using EShopModular.Modules.Orders.Domain.Orders.Rules;

namespace EShopModular.Modules.Orders.Domain.Orders;

// Cannot make this class immutable because of EF Core.
// The default constructor is required by DI.
public class Order : Entity, IAggregateRoot
{
    public OrderId Id { get; private set; }

    private decimal _shippingCost;
    private decimal _totalCost;
    private string _currency;
    private decimal _exchangeRate;
    private DateTime _createDate;
    private List<OrderItem> _orderItems;

    public static Order CreateNew(
        string commandCurrency,
        decimal commandShippingCost,
        decimal commandTotalCost,
        decimal commandExchangeRate,
        DateTime now)
    {
        return new Order(new OrderId(Guid.NewGuid()), commandCurrency, commandShippingCost, commandTotalCost, commandExchangeRate, now);
    }

    private Order()
    {
        _orderItems = new List<OrderItem>();
    }

    private Order(
        OrderId id,
        string currency,
        decimal shippingCost,
        decimal totalCost,
        decimal exchangeRate,
        DateTime createDate)
    {
        CheckRule(new OrderCurrencyMustBeValidRule(currency));

        Id = id;
        _currency = currency;
        _shippingCost = shippingCost;
        _totalCost = totalCost;
        _exchangeRate = exchangeRate;
        _createDate = createDate;
        _orderItems = new List<OrderItem>();

        AddDomainEvent(new OrderCreatedDomainEvent(Id));
    }

    public void AddItem(Guid productId, int argQuantity, decimal productPrice)
    {
        _orderItems.Add(OrderItem.CreateNew(Id, productId, argQuantity, productPrice));
    }
}
#nullable enable