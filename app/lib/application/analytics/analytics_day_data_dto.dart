import 'package:openems/application/backend_api/backend_api.dart';

class AnalyticsDayDataDto {
  final DateTime start;
  final DateTime end;
  final List<PowerDataPointDto> home;
  final List<PowerDataPointDto> production;
  final List<PowerDataPointDto> gridConsume;
  final List<PowerDataPointDto> gridFeedIn;

  AnalyticsDayDataDto({
    required this.start,
    required this.end,
    required this.home,
    required this.production,
    required this.gridConsume,
    required this.gridFeedIn,
  });
}
