using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.Countries;

public class CountryId : TypedIdValueBase
{
    public CountryId(Guid value)
        : base(value)
    {
    }
}