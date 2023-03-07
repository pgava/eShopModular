﻿using EShopModular.Common.Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;

namespace EShopModular.Common.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public UnitOfWork(
        DbContext context,
        IDomainEventsDispatcher domainEventsDispatcher)
    {
        this._context = context;
        this._domainEventsDispatcher = domainEventsDispatcher;
    }

    public async Task<int> CommitAsync(
        CancellationToken cancellationToken = default,
        Guid? internalCommandId = null)
    {
        await this._domainEventsDispatcher.DispatchEventsAsync();

        return await _context.SaveChangesAsync(cancellationToken);
    }
}