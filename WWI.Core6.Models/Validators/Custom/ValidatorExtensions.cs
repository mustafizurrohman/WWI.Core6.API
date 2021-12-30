using FluentValidation;
using FluentValidation.Validators;

namespace WWI.Core6.Models.Validators.Custom;

/// <summary>
/// 
/// </summary>
public static class ValidatorExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TElement"></typeparam>
    /// <param name="ruleBuilder"></param>
    /// <param name="num"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num) {
        return ruleBuilder.SetValidator(new ListCountValidator<T, TElement>(num));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> MustBeValidName<T>(this IRuleBuilder<T, string> rule)
    {
        return rule
            .MustNotBeNullOrEmpty()
            .MaximumLength(30)
            .WithMessage("'{PropertyName}' cannot have more than 30 characters")
            .NotContainNumbersOrSpecialCharacters()
            .NotStartWithWhiteSpace()
            .NotEndWithWhiteSpace();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, string> MustBeValidMiddleName<T>(this IRuleBuilder<T, string> rule)
    {
        return rule
            .MustNotBeNullOrEmpty()
            .MaximumLength(30)
            .WithMessage("'{PropertyName}' cannot have more than 30 characters")
            .NotStartWithWhiteSpace()
            .NotEndWithWhiteSpace()
            .NotContainNumbersOrSpecialCharacters();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="rule"></param>
    /// <returns></returns>
    public static IRuleBuilderOptions<T, TProperty> MustNotBeNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> rule)
    {
        return rule
            .SetValidator(new NotEmptyValidator<T, TProperty>())
                .WithMessage("'{PropertyName}' cannot be empty.")
            .SetValidator(new NotNullValidator<T, TProperty>())
                .WithMessage("'{PropertyName}' cannot be Null.");
    }

}