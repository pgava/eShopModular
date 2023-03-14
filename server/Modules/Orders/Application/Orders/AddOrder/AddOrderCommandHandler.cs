using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Domain.SharedKernel;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>, ICommandHandler
{
    private readonly IOrderRepository _orderRepository;

    public AddOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(AddOrderCommand command, CancellationToken cancellationToken)
    {
        var orderId = new OrderId(Guid.NewGuid());

        var order = new Order(
            orderId,
            command.Currency,
            command.OrderItems.Select(s => new OrderItem(
                new OrderItemId(Guid.NewGuid()),
                orderId,
                s.Product.Id,
                s.Quantity,
                s.Product.Price)).ToList(),
            command.ShippingCost,
            command.TotalCost,
            command.ExchangeRate,
            SystemClock.Now);

        await _orderRepository.AddOrderAsync(order, cancellationToken);
    }
}
