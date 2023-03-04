using System.Reflection;
using EShopModular.Modules.Orders.Application.Configuration.Queries;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}