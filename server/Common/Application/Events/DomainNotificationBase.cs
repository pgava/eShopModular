﻿using EShopModular.Common.Domain;

namespace EShopModular.Common.Application.Events;

public class DomainNotificationBase<T> : IDomainEventNotification<T>
    where T : IDomainEvent
{
    public T DomainEvent { get; }

    public Guid Id { get; }

    public DomainNotificationBase(T domainEvent, Guid id)
    {
        this.Id = id;
        this.DomainEvent = domainEvent;
    }
}