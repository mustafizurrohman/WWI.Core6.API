namespace WWI.Core6.Core.ExtensionMethods;

public static class FluentValidationResultExtensions
{
    public static string ToErrorString(this FluentValidation.Results.ValidationResult validationResult)
    {
        if (validationResult.IsValid)
            return string.Empty;

        return validationResult.Errors
            .Select((e, index) => (index + 1) + "- " + e)
            .Aggregate((e1, e2) => e1 + Environment.NewLine + e2);
    }
}
