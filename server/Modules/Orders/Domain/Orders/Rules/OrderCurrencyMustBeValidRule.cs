using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Orders.Rules;

public class OrderCurrencyMustBeValidRule : IBusinessRule
{
    private readonly string _currency;

    public OrderCurrencyMustBeValidRule(string currency)
    {
        _currency = currency;
    }

    public bool IsBroken()
    {
        // Add logic here
        return false;
    }

    public string Message => "Order currency must be valid";
}