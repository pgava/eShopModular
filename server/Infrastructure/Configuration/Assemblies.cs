using System.Reflection;
using eShopCmc.Application.Configuration.Queries;

namespace eShopCmc.Infrastructure.Configuration
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(QueryBase<>).Assembly;
    }
}