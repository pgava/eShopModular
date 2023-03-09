namespace EShopModular.Modules.Orders.Infrastructure.Configuration.Processing.Outbox;

public class OutboxMessageDto
{
    public OutboxMessageDto(Guid id, string type, string data)
    {
        Id = id;
        Type = type;
        Data = data;
    }

    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }
}