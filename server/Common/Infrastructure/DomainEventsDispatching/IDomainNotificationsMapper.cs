namespace EShopModular.Common.Infrastructure.DomainEventsDispatching;

public interface IDomainNotificationsMapper
{
    string GetName(Type type);

    Type GetType(string name);
}