using MediatR;

namespace eShopCmc.Application.Contracts;

public interface ICommand : IRequest
{
    Guid Id { get; }
}