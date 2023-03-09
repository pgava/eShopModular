namespace EShopModular.Common.Infrastructure.InternalCommands;

public class InternalCommand
{
    public InternalCommand(Guid id, string type, string data)
    {
        Id = id;
        Type = type;
        Data = data;
    }

    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Data { get; set; }

    public DateTime? ProcessedDate { get; set; }
}