using Autofac;

namespace eShopModular.Modules.Products.Infrastructure.Configuration;
internal static class EShopProductsCompositionRoot
{
    private static IContainer? _container;

    internal static void SetContainer(IContainer? container)
    {
        _container = container;
    }

    internal static ILifetimeScope BeginLifetimeScope()
    {
        if (_container == null)
        {
            throw new InvalidOperationException("Container not initialized");
        }

        return _container.BeginLifetimeScope();
    }
}
