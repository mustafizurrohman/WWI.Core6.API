namespace WWI.Core6.Services.Validation.Custom
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> MustBeValidName<T>(this IRuleBuilder<T, string> rule)
        {
            return rule
                .NotEmpty()
                    .WithMessage("'{PropertyName}' should not be empty")
                .NotNull()
                    .WithMessage("'{PropertyName}' should not be null")
                .MaximumLength(30)
                    .WithMessage("'{PropertyName}' cannot have more than 30 characters")
                .NotContainNumbersOrSpecialCharacters()
                .NotStartWithWhiteSpace()
                .NotEndWithWhiteSpace();
        }

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

            bool NotContainNumbers(string name)
            {
                return !name.Any(char.IsDigit);
            }
        } 
        
    }
}
