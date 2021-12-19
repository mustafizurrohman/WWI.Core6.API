using FluentValidation;
using WWI.Core6.Models.AppSettings;

namespace WWI.Core6.Models.Validators
{
    /// <summary>
    /// Class PerformanceOptionsValidator.
    /// Implements the <see cref="PerformanceOptions" />
    /// </summary>
    /// <seealso cref="PerformanceOptions" />
    public class PerformanceOptionsValidator : AbstractValidator<PerformanceOptions>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceOptionsValidator"/> class.
        /// </summary>
        public PerformanceOptionsValidator()
        {
            RuleFor(po => po.UseExceptionHandlingMiddleware)
                .NotNull()
                .WithMessage("{PropertyName} must be specified");

            RuleFor(po => po.UseResponseCompression)
                .NotNull()
                .WithMessage("{PropertyName} must be specified");

        }
    }
}
