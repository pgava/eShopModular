using Autofac;
using eShopModular.Modules.Orders.Application.Contracts;
using eShopModular.Modules.Orders.Infrastructure;
using eShopModular.Modules.Products.Application.Contracts;
using eShopModular.Modules.Products.Infrastructure;

namespace eShopModular.Api
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