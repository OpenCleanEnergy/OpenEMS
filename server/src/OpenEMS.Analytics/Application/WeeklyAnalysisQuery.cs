using System.ComponentModel.DataAnnotations;
using OpenEMS.Analytics.Queries;
using OpenEMS.Application.Shared;

namespace OpenEMS.Analytics.Application;

public class WeeklyAnalysisQuery : IQuery<WeeklyAnalysisDto>
{
    [Range(1, int.MaxValue)]
    public required int Year { get; init; }

    [Range(1, 12)]
    public required int Month { get; init; }

    [Range(1, 31)]
    public required int FirstDayOfWeek { get; init; }
    public required TimeSpan TimeZoneOffset { get; init; }

    public class Handler(
        IAnalyticsEnergyHistoryQuery energyHistoryQuery,
        IAnalyticsTotalEnergyDataQuery totalEnergyDataQuery
    ) : IQueryHandler<WeeklyAnalysisQuery, WeeklyAnalysisDto>
    {
        private readonly IAnalyticsEnergyHistoryQuery _energyHistoryQuery = energyHistoryQuery;
        private readonly IAnalyticsTotalEnergyDataQuery _totalEnergyDataQuery =
            totalEnergyDataQuery;

        public async Task<WeeklyAnalysisDto> Handle(
            WeeklyAnalysisQuery request,
            CancellationToken cancellationToken
        )
        {
            var start = new DateTimeOffset(
                year: request.Year,
                month: request.Month,
                day: request.FirstDayOfWeek,
                hour: 0,
                minute: 0,
                second: 0,
                offset: request.TimeZoneOffset
            );

            var intervals = Enumerable
                .Range(start: 0, count: 7)
                .Select(day => new EnergyHistoryQueryInterval<DayOfWeek>
                {
                    Key = start.AddDays(day).DayOfWeek,
                    Start = start.AddDays(day),
                    End = start.AddDays(day + 1),
                })
                .ToArray();

            var energyHistory = await _energyHistoryQuery.GetEnergyHistory(intervals);
            var totalEnergyData = await _totalEnergyDataQuery.QueryTotalEnergyData(
                start,
                start.AddDays(7)
            );

            return new WeeklyAnalysisDto
            {
                EnergyHistory = WeeklyEnergyHistoryDto.From(energyHistory),
                Metrics = AnalyticsMetricsDto.From(totalEnergyData),
            };
        }
    }
}
