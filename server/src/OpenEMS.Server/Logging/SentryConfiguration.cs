﻿using Serilog.Events;

namespace OpenEMS.Server.Logging;

public class SentryConfiguration
{
    public bool Debug { get; init; }
    public string? Dsn { get; init; }
    public LogEventLevel MinimumBreadcrumbLevel { get; init; } = LogEventLevel.Information;
    public LogEventLevel MinimumEventLevel { get; init; } = LogEventLevel.Error;
}
