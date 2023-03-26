namespace EShopModular.Modules.Orders.Application.Orders.GetOrderDetails;

public class OrderDetailsDto
{
    public OrderDetailsDto(
        Guid id,
        DateTime createDate,
        decimal shippingCost,
        decimal totalCost,
        string currency,
        decimal exchangeRate)
    {
        Id = id;
        CreateDate = createDate;
        ShippingCost = shippingCost;
        TotalCost = totalCost;
        Currency = currency;
        ExchangeRate = exchangeRate;
    }

    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public decimal ShippingCost { get; set; }

    public decimal TotalCost { get; set; }

    public string Currency { get; set; }

    public decimal ExchangeRate { get; set; }
}