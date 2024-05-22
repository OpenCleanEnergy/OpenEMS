using System.Text.Json.Serialization;
using Emma.Integrations.Shelly.Domain.ValueObjects;

namespace Emma.Integrations.Shelly.Commands.Relay;

public class ShellyRelayCommandRequestDataParameters
{
    internal ShellyRelayCommandRequestDataParameters(ShellyChannelIndex id, string turn)
    {
        Id = id;
        Turn = turn;
    }

    /// <summary>
    /// Gets the device channel.
    /// </summary>
    [JsonPropertyName("id")]
    public ShellyChannelIndex Id { get; }

    /// <summary>
    /// Gets the command action: on | off | toggle.
    /// </summary>
    [JsonPropertyName("turn")]
    public string Turn { get; }
}
