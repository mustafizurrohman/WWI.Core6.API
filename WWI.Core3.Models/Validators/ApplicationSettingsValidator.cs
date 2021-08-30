using FluentValidation;
using WWI.Core3.Models.AppSettings;

namespace WWI.Core3.Models.Validators
{

    /// <summary>
    /// Class ApplicationSettingsValidator.
    /// Implements the <see cref="ApplicationSettings" />
    /// </summary>
    /// <seealso cref="ApplicationSettings" />
    public class ApplicationSettingsValidator : AbstractValidator<ApplicationSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSettingsValidator"/> class.
        /// </summary>
        public ApplicationSettingsValidator()
        {
            RuleFor(appsettings => appsettings.OpenApiInfo)
                .SetValidator(new OpenApiInfoValidator());

            RuleFor(appsettings => appsettings.PerformanceOptions)
                .SetValidator(new PerformanceOptionsValidator());

            RuleFor(appSettings => appSettings.ConnectionString)
                .SetValidator(new DatabaseConnectionStringValidator());
        }

    }
}
