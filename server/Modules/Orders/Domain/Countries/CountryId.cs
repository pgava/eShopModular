using eShopModular.Common.Domain;

namespace eShopModular.Modules.Orders.Domain.Countries;

public class CountryId : TypedIdValueBase
{
    public CountryId(Guid value)
        : base(value)
    {
    }
}