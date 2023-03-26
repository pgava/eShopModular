using System.Reflection;
using EShopModular.Modules.Orders.Application.Configuration.Commands;
using EShopModular.Modules.Orders.Application.Configuration.Queries;
using EShopModular.Modules.Orders.Application.Contracts;
using EShopModular.Modules.Orders.ArchTests.SeedWork;
using FluentValidation;
using NetArchTest.Rules;

namespace EShopModular.Modules.Orders.ArchTests.Application;

public class ApplicationTests : TestBase
{
    [Fact]
    public void Command_Should_Be_Immutable()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(CommandBase))
            .Or()
            .Inherit(typeof(CommandBase<>))
            .Or()
            .Inherit(typeof(InternalCommandBase))
            .Or()
            .Inherit(typeof(InternalCommandBase<>))
            .Or()
            .ImplementInterface(typeof(ICommand))
            .Or()
            .ImplementInterface(typeof(ICommand<>))
            .GetTypes();

        AssertAreImmutable(types);
    }

    [Fact]
    public void Query_Should_Be_Immutable()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That().ImplementInterface(typeof(IQuery<>)).GetTypes();

        AssertAreImmutable(types);
    }

    [Fact]
    public void CommandHandler_Should_Have_Name_EndingWith_CommandHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler))
            .And()
            .DoNotHaveNameMatching(".*Decorator.*").Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        AssertArchTestResult(result);
    }

    [Fact]
    public void QueryHandler_Should_Have_Name_EndingWith_QueryHandler()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        AssertArchTestResult(result);
    }

    [Fact]
    public void Command_And_Query_Handlers_Should_Not_Be_Public()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Or()
            .ImplementInterface(typeof(ICommandHandler))
            .Should().NotBePublic().GetResult().FailingTypes;

        AssertFailingTypes(types);
    }

    [Fact]
    public void Validator_Should_Have_Name_EndingWith_Validator()
    {
        var result = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should()
            .HaveNameEndingWith("Validator")
            .GetResult();

        AssertArchTestResult(result);
    }

    [Fact]
    public void Validators_Should_Not_Be_Public()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(AbstractValidator<>))
            .Should().NotBePublic().GetResult().FailingTypes;

        AssertFailingTypes(types);
    }

    [Fact]
    public void InternalCommand_Should_Have_Constructor_With_JsonConstructorAttribute()
    {
        var types = Types.InAssembly(ApplicationAssembly)
            .That()
            .Inherit(typeof(InternalCommandBase))
            .Or()
            .Inherit(typeof(InternalCommandBase<>))
            .GetTypes();

        var failingTypes = new List<Type>();

        foreach (var type in types)
        {
            bool hasJsonConstructorDefined = false;
            var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (var constructorInfo in constructors)
            {
                var jsonConstructorAttribute = constructorInfo.GetCustomAttributes(typeof(System.Text.Json.Serialization.JsonConstructorAttribute), false);
                if (jsonConstructorAttribute.Length > 0)
                {
                    hasJsonConstructorDefined = true;
                    break;
                }
            }

            if (!hasJsonConstructorDefined)
            {
                failingTypes.Add(type);
            }
        }

        AssertFailingTypes(failingTypes);
    }
}