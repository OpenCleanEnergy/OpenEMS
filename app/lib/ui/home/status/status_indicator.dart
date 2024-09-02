import 'package:emma/ui/shared/unit_text.dart';
import 'package:flutter/material.dart';
import 'package:signals/signals_flutter.dart';

class StatusIndicator extends StatefulWidget {
  const StatusIndicator({
    super.key,
    required this.icon,
    required this.value,
    required this.unit,
    this.maxValue,
  });

  final ReadonlySignal<IconData> icon;
  final ReadonlySignal<double> value;
  final ReadonlySignal<double>? maxValue;
  final String unit;

  @override
  State<StatusIndicator> createState() => _StatusIndicatorState();
}

class _StatusIndicatorState extends State<StatusIndicator> {
  static const double _indicatorSize = 96;
  static const double _iconSize = 32;

  late final _indicatorValue = computed(() {
    final value = widget.value.value.round();
    final maxValue = widget.maxValue?.value.round() ?? 0;

    if (value == 0) {
      return 0.0;
    } else if (maxValue == 0) {
      return 1.0;
    } else if (maxValue < value) {
      return 1.0;
    }

    final fraction = value / maxValue;
    // Round to 2 decimal places
    final rounded = (fraction * 100).round() / 100;

    // As long as the value is greater than 0,
    // the rounded value should be at least 0.01
    return value > 0 && rounded == 0 ? 0.01 : rounded;
  });

  late final _tween = computed(() => Tween<double>(
        begin: _indicatorValue.previousValue ?? 0.0,
        end: _indicatorValue.value,
      ));

  @override
  void dispose() {
    _indicatorValue.dispose();
    _tween.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Stack(
      alignment: Alignment.center,
      children: [
        Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Watch((context) => Icon(widget.icon.value, size: _iconSize)),
            Watch((context) => UnitText(widget.value.value, widget.unit)),
          ],
        ),
        SizedBox.square(
          dimension: _indicatorSize,
          child: Watch(
            (context) => TweenAnimationBuilder<double>(
              tween: _tween.value,
              duration: const Duration(milliseconds: 500),
              curve: Curves.easeInOut,
              builder: (context, value, _) => CircularProgressIndicator(
                value: value,
                strokeWidth: 8,
                backgroundColor:
                    Theme.of(context).colorScheme.secondaryContainer,
              ),
            ),
          ),
        )
      ],
    );
  }
}
