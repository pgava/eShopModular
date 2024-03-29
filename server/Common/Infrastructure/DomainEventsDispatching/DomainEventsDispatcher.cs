﻿using Autofac;
using Autofac.Core;
using EShopModular.Common.Application.Events;
using EShopModular.Common.Application.Outbox;
using EShopModular.Common.Domain;
using EShopModular.Common.Infrastructure.Serialization;
using MediatR;
using Newtonsoft.Json;

namespace EShopModular.Common.Infrastructure.DomainEventsDispatching;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;

    private readonly ILifetimeScope _scope;

    private readonly IOutbox _outbox;

    private readonly IDomainEventsAccessor _domainEventsProvider;

    private readonly IDomainNotificationsMapper _domainNotificationsMapper;

    public DomainEventsDispatcher(
        IMediator mediator,
        ILifetimeScope scope,
        IOutbox outbox,
        IDomainEventsAccessor domainEventsProvider,
        IDomainNotificationsMapper domainNotificationsMapper)
    {
        _mediator = mediator;
        _scope = scope;
        _outbox = outbox;
        _domainEventsProvider = domainEventsProvider;
        _domainNotificationsMapper = domainNotificationsMapper;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEvents = _domainEventsProvider.GetAllDomainEvents();

        var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
        foreach (var domainEvent in domainEvents)
        {
            Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
            var domainNotificationWithGenericType = domainEvenNotificationType.MakeGenericType(domainEvent.GetType());
            var domainNotification = _scope.ResolveOptional(domainNotificationWithGenericType, new List<Parameter>
            {
                new NamedParameter("domainEvent", domainEvent),
                new NamedParameter("id", domainEvent.Id)
            });

            if (domainNotification is IDomainEventNotification<IDomainEvent> domainEventNotification)
            {
                domainEventNotifications.Add(domainEventNotification);
            }
        }

        _domainEventsProvider.ClearAllDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        foreach (var domainEventNotification in domainEventNotifications)
        {
            var type = _domainNotificationsMapper.GetName(domainEventNotification.GetType());
            var data = JsonConvert.SerializeObject(domainEventNotification, new JsonSerializerSettings
            {
                ContractResolver = new AllPropertiesContractResolver()
            });

            var outboxMessage = new OutboxMessage(
                domainEventNotification.Id,
                domainEventNotification.DomainEvent.OccurredOn,
                type,
                data);

            _outbox.Add(outboxMessage);
        }
    }
}