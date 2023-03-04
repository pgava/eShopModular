using Autofac;
using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Infrastructure;
using EShopModular.Modules.Products.Application.Contracts;
using EShopModular.Modules.Products.Infrastructure;

namespace EShopModular.Api
{
    public class EShopAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EShopOrdersModule>()
                .As<IEShopOrdersModule>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EShopProductsModule>()
                .As<IEShopProductsModule>()
                .InstancePerLifetimeScope();
        }
    }
}