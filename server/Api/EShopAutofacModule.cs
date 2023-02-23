using Autofac;
using eShopModular.Application.Contracts;
using eShopModular.Infrastructure;

namespace eShopModular.Api
{
    public class EShopAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EShopCmcModule>()
                .As<IEShopCmcModule>()
                .InstancePerLifetimeScope();
        }
    }
}