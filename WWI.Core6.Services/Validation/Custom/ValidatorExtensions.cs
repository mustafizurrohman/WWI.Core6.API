using FluentValidation.Validators;

namespace WWI.Core6.Services.Validation.Custom;

public static class ValidatorExtensions
{
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainFewerThan<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num) {
        return ruleBuilder.SetValidator(new ListCountValidator<T, TElement>(num));
    }

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

    public static IRuleBuilderOptions<T, TProperty> MustNotBeNullOrEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> rule)
    {
        return rule
            .SetValidator(new NotEmptyValidator<T, TProperty>())
                .WithMessage("'{PropertyName}' cannot be empty.")
            .SetValidator(new NotNullValidator<T, TProperty>())
                .WithMessage("'{PropertyName}' cannot be Null.");
    }

}