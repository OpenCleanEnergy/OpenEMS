using Vogen;

namespace Emma.Domain;

[ValueObject<string>(comparison: ComparisonGeneration.Omit)]
public readonly partial record struct IntegrationDeviceId
{
    private static Validation Validate(string input)
    {
        return string.IsNullOrWhiteSpace(input)
            ? Validation.Invalid(
                $"{nameof(IntegrationDeviceId)} must not be null or empty or whitespace."
            )
            : Validation.Ok;
    }
}
