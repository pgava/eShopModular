using System.Reflection;
using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.Domain.Orders;
using EShopModular.Modules.Orders.Infrastructure;
using FluentAssertions;
using NetArchTest.Rules;

namespace EShopModular.Modules.Orders.ArchTests.SeedWork;

public abstract class TestBase
{
    protected static Assembly ApplicationAssembly => typeof(CommandBase).Assembly;

    protected static Assembly DomainAssembly => typeof(Order).Assembly;

    protected static Assembly InfrastructureAssembly => typeof(EShopOrdersContext).Assembly;

    protected static void AssertAreImmutable(IEnumerable<Type> types)
    {
        IList<Type> failingTypes = new List<Type>();
        foreach (var type in types)
        {
            if (type.GetFields().Any(x => !x.IsInitOnly) || type.GetProperties().Any(x => x.CanWrite))
            {
                failingTypes.Add(type);
                break;
            }
        }

        AssertFailingTypes(failingTypes);
    }

    protected static void AssertFailingTypes(IEnumerable<Type> types)
    {
        types.Should().BeNullOrEmpty();
    }

    protected static void AssertArchTestResult(TestResult result)
    {
        AssertFailingTypes(result.FailingTypes);
    }
}