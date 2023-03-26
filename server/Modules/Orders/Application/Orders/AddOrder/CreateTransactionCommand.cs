using System.Text.Json.Serialization;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Contracts;

namespace EShopModular.Modules.Orders.Application.Orders.AddOrder;

internal class CreateTransactionCommand : InternalCommandBase
{
    [JsonConstructor]
    public CreateTransactionCommand(
        Guid id)
        : base(id)
    {
    }
}