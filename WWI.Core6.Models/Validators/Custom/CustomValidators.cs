using FluentValidation;

namespace WWI.Core6.Models.Validators.Custom;

/// <summary>
/// 
/// </summary>
public static class CustomValidators
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> NotStartWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)     
    {         
        return ruleBuilder.Must(m => m != null && !m.StartsWith(" "))
            .WithMessage("'{PropertyName}' should not start with whitespace");     
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> NotEndWithWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)     
    {         
        return ruleBuilder.Must(m => m != null && !m.EndsWith(" "))
            .WithMessage("'{PropertyName}' should not end with whitespace");     
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> NotContainNumbersOrSpecialCharacters<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must(NotContainNumbers)
            .WithMessage("'{PropertyName}' must not contain numbers");

        bool NotContainNumbers(string name) => !name.Any(char.IsDigit);
    }
}