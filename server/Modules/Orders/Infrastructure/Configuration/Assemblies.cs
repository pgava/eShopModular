using System.Reflection;
using eShopModular.Modules.Orders.Application.Configuration.Queries;

namespace eShopModular.Modules.Orders.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}