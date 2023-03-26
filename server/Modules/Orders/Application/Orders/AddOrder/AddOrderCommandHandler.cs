using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Domain.SharedKernel;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

internal class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>, ICommandHandler
{
    private readonly IOrderRepository _orderRepository;

    public AddOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Guid> Handle(AddOrderCommand command, CancellationToken cancellationToken)
    {
        var order = Order.CreateNew(
            command.Currency,
            command.ShippingCost,
            command.TotalCost,
            command.ExchangeRate,
            SystemClock.Now);

        command.OrderItems.ForEach(s => order.AddItem(
            s.Product.Id,
            s.Quantity,
            s.Product.Price));

        await _orderRepository.AddOrderAsync(order, cancellationToken);

        return order.Id.Value;
    }
}
