using eShopModular.Modules.Orders.Application.Configuration.Commands;
using eShopModular.Modules.Orders.Domain.Orders;
using MediatR;

namespace eShopModular.Modules.Orders.Application.Orders.AddOrder;

public class AddOrderCommandHandler : ICommandHandler<AddOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    public AddOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public async Task<Unit> Handle(AddOrderCommand command, CancellationToken cancellationToken)
    {
        if (command.Products == null || command.Products.Count == 0)
        {
            throw new ArgumentNullException("No items found.");
        }
        
        var orderId = new OrderId(Guid.NewGuid());
        var order = new Order
        (
            orderId,
            command.Currency,
            command.Products.Select(s => new OrderItem
            (
                new OrderItemId(Guid.NewGuid()),
                orderId,
                s.Product.Id,
                s.Quantity,
                s.Product.Price
            )).ToList(),
            command.ShippingCost,
            command.TotalCost,
            command.ExchangeRate,
            DateTime.UtcNow
        );

        await _orderRepository.AddOrderAsync(order, cancellationToken);
        return Unit.Value;
    }
}
