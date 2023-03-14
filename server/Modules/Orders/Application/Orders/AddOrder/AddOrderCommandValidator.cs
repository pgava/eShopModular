using FluentValidation;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder
{
    internal class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(c => c.OrderItems).NotEmpty()
                .WithMessage("Order items cannot be empty.");
        }
    }
}