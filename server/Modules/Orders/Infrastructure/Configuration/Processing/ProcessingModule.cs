using Autofac;
using EShopModular.Common.Application.Events;
using EShopModular.Common.Infrastructure;
using EShopModular.Common.Infrastructure.DomainEventsDispatching;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Infrastructure.Configuration.Processing.InternalCommands;
using MediatR;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing;

internal class ProcessingModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<DomainEventsDispatcher>()
            .As<IDomainEventsDispatcher>()
            .InstancePerLifetimeScope();

        builder.RegisterType<DomainEventsAccessor>()
            .As<IDomainEventsAccessor>()
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        builder.RegisterType<CommandsScheduler>()
            .As<ICommandsScheduler>()
            .InstancePerLifetimeScope();

        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkCommandHandlerDecorator<>),
            typeof(IRequestHandler<>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(UnitOfWorkCommandHandlerWithResultDecorator<,>),
            typeof(IRequestHandler<,>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(ValidationCommandHandlerDecorator<>),
            typeof(IRequestHandler<>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(ValidationCommandHandlerWithResultDecorator<,>),
            typeof(IRequestHandler<,>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(LoggingCommandHandlerDecorator<>),
            typeof(IRequestHandler<>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(LoggingCommandHandlerWithResultDecorator<,>),
            typeof(IRequestHandler<,>),
            context =>
            {
                return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
            });

        builder.RegisterGenericDecorator(
            typeof(DomainEventsDispatcherNotificationHandlerDecorator<>),
            typeof(INotificationHandler<>));

        builder.RegisterAssemblyTypes(Assemblies.Application)
            .AsClosedTypesOf(typeof(IDomainEventNotification<>))
            .InstancePerDependency()
            .FindConstructorsWith(new AllConstructorFinder());
    }
}