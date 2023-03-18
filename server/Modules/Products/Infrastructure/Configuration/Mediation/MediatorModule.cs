using System.Reflection;
using Autofac;
using Autofac.Core;
using Autofac.Features.Variance;
using EShopModular.Modules.Products.Application.Products;
using FluentValidation;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR.Pipeline;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Mediation
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = MediatRConfigurationBuilder
                .Create(
                    typeof(MediatorModule).Assembly, // ThisAssembly
                    typeof(ProductDto).Assembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            // this will add all your Request- and Notificationhandler
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