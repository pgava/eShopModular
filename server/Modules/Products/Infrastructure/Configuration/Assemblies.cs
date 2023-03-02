using System.Reflection;
using eShopModular.Modules.Products.Application.Configuration.Queries;

namespace eShopModular.Modules.Products.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}