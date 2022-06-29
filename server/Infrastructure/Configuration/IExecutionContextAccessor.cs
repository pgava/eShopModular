namespace eShopCmc.Infrastructure.Configuration;

public interface IExecutionContextAccessor
{
    Guid UserId { get; }

    Guid CorrelationId { get; }

    bool IsAvailable { get; }
}