using System.Collections.Concurrent;
using System.Reflection;
using Autofac.Core.Activators.Reflection;

namespace eShopModular.Modules.Products.Infrastructure.Configuration;

/*
 * https://stackoverflow.com/questions/52793062/how-to-resolve-public-class-with-internal-constructor-on-autofac
 */
internal class AllConstructorFinder : IConstructorFinder
{
    private static readonly ConcurrentDictionary<Type, ConstructorInfo[]> Cache =
        new ConcurrentDictionary<Type, ConstructorInfo[]>();

    public ConstructorInfo[] FindConstructors(Type targetType)
    {
        var result = Cache.GetOrAdd(
            targetType,
            t => t.GetTypeInfo().DeclaredConstructors.ToArray());

        return result.Length > 0 ? result : throw new NoConstructorsFoundException(targetType);
    }
}