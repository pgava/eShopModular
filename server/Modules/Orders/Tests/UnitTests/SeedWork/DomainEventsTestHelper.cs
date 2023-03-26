﻿using System.Collections;
using System.Reflection;
using EShopModular.Common.Domain;

namespace EShopModular.Modules.Orders.Domain.UnitTests.SeedWork;

public class DomainEventsTestHelper
{
    public static List<IDomainEvent> GetAllDomainEvents(Entity aggregate)
    {
        List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        if (aggregate.DomainEvents != null)
        {
            domainEvents.AddRange(aggregate.DomainEvents);
        }

        var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

        foreach (var field in fields)
        {
            var isEntity = typeof(Entity).IsAssignableFrom(field.FieldType);

            if (isEntity)
            {
                if (field.GetValue(aggregate) is Entity entity)
                {
                    domainEvents.AddRange(GetAllDomainEvents(entity).ToList());
                }
            }

            if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
            {
                if (field.GetValue(aggregate) is IEnumerable enumerable)
                {
                    foreach (var en in enumerable)
                    {
                        if (en is Entity entityItem)
                        {
                            domainEvents.AddRange(GetAllDomainEvents(entityItem));
                        }
                    }
                }
            }
        }

        return domainEvents;
    }

    public static void ClearAllDomainEvents(Entity aggregate)
    {
        aggregate.ClearDomainEvents();

        var fields = aggregate.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).Concat(aggregate.GetType().BaseType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)).ToArray();

        foreach (var field in fields)
        {
            var isEntity = field.FieldType.IsAssignableFrom(typeof(Entity));

            if (isEntity)
            {
                if (field.GetValue(aggregate) is Entity entity)
                {
                    ClearAllDomainEvents(entity);
                }
            }

            if (field.FieldType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(field.FieldType))
            {
                if (field.GetValue(aggregate) is IEnumerable enumerable)
                {
                    foreach (var en in enumerable)
                    {
                        if (en is Entity entityItem)
                        {
                            ClearAllDomainEvents(entityItem);
                        }
                    }
                }
            }
        }
    }
}