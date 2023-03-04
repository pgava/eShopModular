namespace EShopModular.Modules.Products.Application.Contracts;

public interface IEShopProductsModule
{
    Task ExecuteCommandAsync(ICommand command);

    Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
}