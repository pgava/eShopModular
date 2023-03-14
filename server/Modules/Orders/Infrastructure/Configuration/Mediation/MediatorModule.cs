using Autofac;
using EShopModular.Modules.Orders.Application.Orders.AddOrder;
using FluentValidation;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Mediation
{
    public class MediatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // This uses a helper nuget package to register all handlers
            // https://github.com/alsami/MediatR.Extensions.Autofac.DependencyInjection
            var configuration = MediatRConfigurationBuilder
                .Create(
                    typeof(MediatorModule).Assembly, // ThisAssembly
                    typeof(OrderItemDto).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            // this will add all your Request- and NotificationHandler
            // that are located in the same project
            builder.RegisterMediatR(configuration);

            // Add validators,...
            var mediatorOpenTypes = new[]
            {
                typeof(IValidator<>)
            };

            foreach (var mediatorOpenType in mediatorOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(ThisAssembly, Assemblies.Application)
                    .AsClosedTypesOf(mediatorOpenType)
                    .AsImplementedInterfaces()
                    .FindConstructorsWith(new AllConstructorFinder());
            }
        }
    }
}