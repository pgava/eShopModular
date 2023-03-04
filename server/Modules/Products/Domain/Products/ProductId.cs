using EShopModular.Common.Domain;

namespace EShopModular.Modules.Products.Domain.Products;

public class ProductId : TypedIdValueBase
{
    public ProductId(Guid value)
        : base(value)
    {
    }
}