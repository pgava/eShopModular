using eShopModular.Common.Domain;

namespace eShopModular.Domain.Products;

public class ProductId : TypedIdValueBase
{
    public ProductId(Guid value)
        : base(value)
    {
    }
}