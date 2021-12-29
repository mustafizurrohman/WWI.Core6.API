namespace WWI.Core6.Services.Validation.Custom;

public static class CustomValidators
{
    public static IRuleBuilderOptions<T, string> NotStartWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)     
    {         
        return ruleBuilder.Must(m => m != null && !m.StartsWith(" "))
            .WithMessage("'{PropertyName}' should not start with whitespace");     
    }

    public static IRuleBuilderOptions<T, string> NotEndWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)     
    {         
        return ruleBuilder.Must(m => m != null && !m.EndsWith(" "))
            .WithMessage("'{PropertyName}' should not end with whitespace");     
    }

    public static IRuleBuilderOptions<T, string> NotContainNumbersOrSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(NotContainNumbers)
            .WithMessage("'{PropertyName}' must not contain numbers");

        bool NotContainNumbers(string name) => !name.Any(char.IsDigit);
    }
}