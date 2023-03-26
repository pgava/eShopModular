using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Domain.SharedKernel;
using MediatR;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand>, ICommandHandler
{
    private readonly IOrderRepository _orderRepository;

    public CreateTransactionCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
    {
        await Task.Delay(100, cancellationToken);
    }
}
