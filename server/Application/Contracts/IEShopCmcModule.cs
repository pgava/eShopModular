
namespace eShopModular.Application.Contracts;

public interface IEShopCmcModule
{
    Task ExecuteCommandAsync(ICommand command);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}