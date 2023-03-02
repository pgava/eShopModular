using eShopModular.Common.Domain;

namespace eShopModular.Modules.Products.Domain.Products;

public class ProductId : TypedIdValueBase
{
    public ProductId(Guid value)
        : base(value)
    {
    }
}