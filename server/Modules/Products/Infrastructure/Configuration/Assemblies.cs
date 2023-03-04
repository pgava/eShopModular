using System.Reflection;
using EShopModular.Modules.Products.Application.Configuration.Queries;

namespace EShopModular.Modules.Products.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}