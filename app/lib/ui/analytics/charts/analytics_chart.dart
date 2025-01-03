import 'package:openems/ui/analytics/analysis_view_model.dart';
import 'package:openems/ui/analytics/analytics_view_model.dart';
import 'package:openems/ui/analytics/charts/analytics_chart_container.dart';
import 'package:openems/ui/analytics/charts/analytics_chart_control.dart';
import 'package:openems/ui/analytics/charts/analytics_day_chart.dart';
import 'package:flutter/material.dart';
import 'package:openems/ui/analytics/charts/analytics_month_chart.dart';
import 'package:openems/ui/analytics/charts/analytics_week_chart.dart';
import 'package:openems/ui/analytics/charts/analytics_year_chart.dart';
import 'package:signals/signals_flutter.dart';

class AnalyticsChart extends StatelessWidget {
  const AnalyticsChart({super.key, required this.viewModel});

  final AnalyticsViewModel viewModel;

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisSize: MainAxisSize.min,
      children: [
        AnalyticsChartContainer(
          child: Watch(
            (context) => switch (viewModel.analysis.value) {
              DailyAnalysisViewModel vm => AnalyticsDayChart(
                  chartControlViewModel: viewModel.chartControl,
                  analysisViewModel: vm,
                ),
              WeeklyAnalysisViewModel vm => AnalyticsWeekChart(
                  chartControlViewModel: viewModel.chartControl,
                  analysisViewModel: vm,
                ),
              MonthlyAnalysisViewModel vm => AnalyticsMonthChart(
                  chartControlViewModel: viewModel.chartControl,
                  analysisViewModel: vm,
                ),
              AnnualAnalysisViewModel vm => AnalyticsYearChart(
                  chartControlViewModel: viewModel.chartControl,
                  analysisViewModel: vm,
                ),
            },
          ),
        ),
        const SizedBox(height: 16),
        AnalyticsChartControl(viewModel: viewModel.chartControl),
      ],
    );
  }
}
