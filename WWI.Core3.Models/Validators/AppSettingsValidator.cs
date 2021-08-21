using FluentValidation;
using WWI.Core3.Models.AppSettings;

namespace WWI.Core3.Models.Validators
{

    /// <summary>
    /// Class AppSettingsValidator.
    /// Implements the <see cref="ApplicationSettings" />
    /// </summary>
    /// <seealso cref="ApplicationSettings" />
    class AppSettingsValidator : AbstractValidator<ApplicationSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettingsValidator"/> class.
        /// </summary>
        public AppSettingsValidator()
        {
            RuleFor(appsettings => appsettings.OpenApiInfo)
                .SetValidator(new OpenApiInfoValidator());
        }

    }
}
