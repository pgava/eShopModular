
namespace eShopModular.Modules.Orders.Application.Contracts;

public interface IEShopOrdersModule
{
    Task ExecuteCommandAsync(ICommand command);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}