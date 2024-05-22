using Emma.Domain;
using Emma.Domain.Events;
using Emma.Integrations.Shelly.Domain.ValueObjects;

namespace Emma.Integrations.Shelly.Events;

public abstract class ShellyEvent : IEvent
{
    public abstract EventKey EventKey { get; }
    public DateTimeOffset Timestamp { get; init; } = AmbientTimeProvider.UtcNow;

    public required string Event { get; init; }
    public required ShellyDeviceId DeviceId { get; init; }

    public override string ToString()
    {
        return $"{Event}:{DeviceId}";
    }
}
