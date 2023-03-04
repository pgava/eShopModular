namespace EShopModular.Modules.Orders.Application.Contracts;

public abstract class CommandBase : ICommand
{
    public Guid Id { get; }

    protected CommandBase()
    {
        Id = Guid.NewGuid();
    }
}