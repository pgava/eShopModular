using System.Reflection;
using eShopModular.Application.Configuration.Queries;

namespace eShopModular.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}