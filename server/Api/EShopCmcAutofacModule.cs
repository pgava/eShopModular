using Autofac;
using eShopCmc.Application.Contracts;
using eShopCmc.Infrastructure;

namespace eShopCmc.Api
{
    public class EShopCmcAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EShopCmcModule>()
                .As<IEShopCmcModule>()
                .InstancePerLifetimeScope();
        }
    }
}