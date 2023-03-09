namespace EShopModular.Modules.Products.Infrastructure.Configuration.Processing.Inbox;

public class InboxMessageDto
{
    public InboxMessageDto(Guid id, string type, string data)
    {
        Id = id;
        Type = type;
        Data = data;
    }

    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }
}