import 'package:openems/application/backend_api/swagger_generated_code/backend_api.enums.swagger.dart';
import 'package:openems/application/backend_api/value_objects.dart';
import 'package:openems/ui/icons/app_icons.dart';
import 'package:openems/ui/home/home_view_model.dart';
import 'package:openems/ui/home/status/status_indicator.dart';
import 'package:flutter/material.dart';
import 'package:signals/signals_flutter.dart';

class GridStatusIndicator extends StatefulWidget {
  const GridStatusIndicator({super.key, required this.viewModel});

  final GridStatusViewModel viewModel;

  @override
  State<GridStatusIndicator> createState() => _GridStatusIndicatorState();
}

class _GridStatusIndicatorState extends State<GridStatusIndicator> {
  late final _maximumPower = computed(
    () {
      return switch (widget.viewModel.currentPowerDirection.value) {
        GridPowerDirection.swaggerGeneratedUnknown => const Watt(1.0),
        GridPowerDirection.none => const Watt(1.0),
        GridPowerDirection.consume =>
          widget.viewModel.maximumPowerConsumption.value,
        GridPowerDirection.feedin => widget.viewModel.maximumPowerFeedIn.value,
      };
    },
    debugLabel: "gridStatusIndicator.maximumPower",
  );

  @override
  void dispose() {
    _maximumPower.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return StatusIndicator(
      icon: signal(AppIcons.power_grid),
      value: widget.viewModel.currentPower,
      maxValue: _maximumPower,
      unit: Watt.unit,
    );
  }
}
