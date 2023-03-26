using Dapper;
using EShopModular.Common.Infrastructure;
using EShopModular.Modules.Orders.Application.Configuration.Queries;

namespace EShopModular.Modules.Orders.Application.Orders.GetOrderDetails;

internal class GetOrderDetailsQueryHandler : IQueryHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetOrderDetailsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery query, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        return await connection.QuerySingleAsync<OrderDetailsDto>(
            "SELECT " +
            $"[OrderDetails].[Id] AS [{nameof(OrderDetailsDto.Id)}], " +
            $"[OrderDetails].[CreateDate] AS [{nameof(OrderDetailsDto.CreateDate)}], " +
            $"[OrderDetails].[ShippingCost] AS [{nameof(OrderDetailsDto.ShippingCost)}], " +
            $"[OrderDetails].[TotalCost] AS [{nameof(OrderDetailsDto.TotalCost)}], " +
            $"[OrderDetails].[Currency] AS [{nameof(OrderDetailsDto.Currency)}], " +
            $"[OrderDetails].[ExchangeRate] AS [{nameof(OrderDetailsDto.ExchangeRate)}] " +
            "FROM [order].[Orders] AS [OrderDetails] " +
            "WHERE [OrderDetails].[Id] = @OrderId",
            new
            {
                query.OrderId
            });
    }
}