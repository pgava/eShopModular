using Autofac;

namespace eShopModular.Modules.Orders.Infrastructure.Configuration;
internal static class EShopOrdersCompositionRoot
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
