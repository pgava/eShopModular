using EShopModular.Common.Application;
using EShopModular.Modules.Products.Application.Configuration.Commands;
using EShopModular.Modules.Products.Application.Contracts;
using FluentValidation;
using MediatR;

namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing
{
    internal class ValidationCommandHandlerDecorator<T> : IRequestHandler<T>, ICommandHandler
        where T : ICommand
    {
        private readonly IList<IValidator<T>> _validators;
        private readonly IRequestHandler<T> _decorated;

        public ValidationCommandHandlerDecorator(
            IList<IValidator<T>> validators,
            IRequestHandler<T> decorated)
        {
            this._validators = validators;
            _decorated = decorated;
        }

        public Task Handle(T command, CancellationToken cancellationToken)
        {
            var errors = _validators
                .Select(v => v.Validate(command))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (errors.Any())
            {
                throw new InvalidCommandException(errors.Select(x => x.ErrorMessage).ToList());
            }

            return _decorated.Handle(command, cancellationToken);
        }
    }
}