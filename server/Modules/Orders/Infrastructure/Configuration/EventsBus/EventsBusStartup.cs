﻿using Autofac;
using EShopModular.Common.Infrastructure.EventBus;
using Serilog;

namespace EShopModular.Modules.Orders.Infrastructure.Configuration.EventsBus;

public static class EventsBusStartup
{
    public static void Initialize(
        ILogger logger)
    {
        SubscribeToIntegrationEvents(logger);
    }

    private static void SubscribeToIntegrationEvents(ILogger logger)
    {
        var eventBus = EShopOrdersCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

        // SubscribeToIntegrationEvent<OrderCreatedIntegrationEvent>(eventBus, logger);
    }

    private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger)
        where T : IntegrationEvent
    {
        logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);
        eventBus.Subscribe(
            new IntegrationEventGenericHandler<T>());
    }
}