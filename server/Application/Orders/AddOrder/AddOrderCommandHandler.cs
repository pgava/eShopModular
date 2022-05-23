using eShopCmc.Application.Configuration.Commands;
using eShopCmc.Domain.Orders;
using MediatR;

namespace eShopCmc.Application.Orders.AddOrder;

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
        
        var orderId = Guid.NewGuid();
        var order = new Order
        {
            Id = orderId,
            CreateDate = DateTime.UtcNow,
            Currency = command.Currency,
            ExchangeRate = command.ExchangeRate,
            OrderItems = command.Products.Select(s => new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = s.Product.Id,
                Quantity = s.Quantity,
                Price = s.Product.Price
            }).ToList(),
            ShippingCost = command.ShippingCost,
            TotalCost = command.TotalCost
        };

        await _orderRepository.AddOrderAsync(order, cancellationToken);
        return Unit.Value;
    }
}
