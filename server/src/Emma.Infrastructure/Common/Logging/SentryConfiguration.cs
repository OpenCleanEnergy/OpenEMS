﻿using Serilog.Events;

namespace Emma.Infrastructure.Common.Logging;

public class SentryConfiguration
{
    public bool Debug { get; init; }
    public string? Dsn { get; init; }
    public double? TracesSampleRate { get; init; }
    public LogEventLevel MinimumBreadcrumbLevel { get; init; } = LogEventLevel.Information;
    public LogEventLevel MinimumEventLevel { get; init; } = LogEventLevel.Warning;
}
