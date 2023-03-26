using EShopModular.Common.Domain;
using EShopModular.Modules.Orders.Domain.SharedKernel;
using FluentAssertions;

namespace EShopModular.Modules.Orders.Domain.UnitTests.SeedWork;

public abstract class TestBase : IDisposable
{
    public static T AssertPublishedDomainEvent<T>(Entity aggregate)
        where T : IDomainEvent
    {
        var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

        if (domainEvent == null)
        {
            throw new Exception($"{typeof(T).Name} event not published");
        }

        return domainEvent;
    }

    public static void AssertDomainEventNotPublished<T>(Entity aggregate)
        where T : IDomainEvent
    {
        var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();
        Assert.Null(domainEvent);
    }

    public static List<T> AssertPublishedDomainEvents<T>(Entity aggregate)
        where T : IDomainEvent
    {
        var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

        if (!domainEvents.Any())
        {
            throw new Exception($"{typeof(T).Name} event not published");
        }

        return domainEvents;
    }

    public static void AssertBrokenRule<TRule>(Action testDelegate)
        where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        
        var businessRuleValidationException = Assert.Throws<BusinessRuleValidationException>(testDelegate);
        
        businessRuleValidationException.BrokenRule.Should().BeOfType<TRule>(message);
    }

    public static async Task AssertBrokenRule<TRule>(Func<Task> testDelegate)
        where TRule : class, IBusinessRule
    {
        var message = $"Expected {typeof(TRule).Name} broken rule";
        
        var businessRuleValidationException = await Assert.ThrowsAsync<BusinessRuleValidationException>(testDelegate);
        
        businessRuleValidationException.BrokenRule.Should().BeOfType<TRule>(message);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            SystemClock.Reset();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}