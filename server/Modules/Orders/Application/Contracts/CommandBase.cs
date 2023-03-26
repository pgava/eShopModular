namespace EShopModular.Modules.Orders.Application.Contracts;

public abstract class CommandBase : ICommand
{
    public Guid Id { get; }

    protected CommandBase()
    {
        Id = Guid.NewGuid();
    }
}

public abstract class CommandBase<TResult> : ICommand<TResult>
{
    public Guid Id { get; }

    protected CommandBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected CommandBase(Guid id)
    {
        this.Id = id;
    }
}