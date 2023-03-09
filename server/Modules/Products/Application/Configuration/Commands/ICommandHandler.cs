namespace EShopModular.Modules.Products.Application.Configuration.Commands;

public interface ICommandHandler
{
}

// =========================================================================================================
// With Autofac >= 5.0.0 below interfaces cannot be used in RegisterGenericDecorator because MediatR cannot
// find that this is actually a definition for a IRequestHandler.
// To use the decorator pattern we need to use the IRequestHandler directly.
// > internal class UnitOfWorkCommandHandlerDecorator<T> : ICommandHandler<T> --> won't work
// > internal class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T> --> ok
// The issue with this is that every command/query will be decorated with all the decorators. To avoid this
// we can use the above interface marker.
// > internal class UnitOfWorkCommandHandlerDecorator<T> : IRequestHandler<T>, ICommandHandler
// and then:
// > builder.RegisterGenericDecorator(
// >   typeof(UnitOfWorkCommandHandlerDecorator<>),
// >   typeof(IRequestHandler<>),
// >   context =>
// >   {
// >       return context.ImplementationType.GetInterfaces().Any(t => t == typeof(ICommandHandler));
// >   });
// Reference:
// https://github.com/autofac/Autofac/issues/1098
// https://autofac.readthedocs.io/en/latest/advanced/adapters-decorators.html
// =========================================================================================================

// public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
//     where TCommand : ICommand
// {
// }
//
// public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
//     where TCommand : ICommand<TResult>
// {
// }