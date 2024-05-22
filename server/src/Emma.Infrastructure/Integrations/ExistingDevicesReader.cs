﻿using Emma.Domain;
using Emma.Infrastructure.Persistence;
using Emma.Integrations.Shared;
using Microsoft.EntityFrameworkCore;

namespace Emma.Infrastructure.Integrations;

public class ExistingDevicesReader : IExistingDevicesReader
{
    private readonly AppDbContext _context;

    public ExistingDevicesReader(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<IntegrationIdentifier>> GetExistingDevicesIdentifier()
    {
        return
        [
            .. await GetExistingConsumers(),
            .. await GetExistingProducers(),
            .. await GetExistingElectricityMeters(),
        ];
    }

    private async Task<IReadOnlyCollection<IntegrationIdentifier>> GetExistingConsumers()
    {
        var query =
            from switchConsumer in _context.SwitchConsumers
            select switchConsumer.Integration;

        return await query.AsNoTracking().ToArrayAsync();
    }

    private async Task<IReadOnlyCollection<IntegrationIdentifier>> GetExistingProducers()
    {
        var query = from switchConsumer in _context.Producers select switchConsumer.Integration;
        return await query.AsNoTracking().ToArrayAsync();
    }

    private async Task<IReadOnlyCollection<IntegrationIdentifier>> GetExistingElectricityMeters()
    {
        var query =
            from switchConsumer in _context.ElectricityMeters
            select switchConsumer.Integration;

        return await query.AsNoTracking().ToArrayAsync();
    }
}
