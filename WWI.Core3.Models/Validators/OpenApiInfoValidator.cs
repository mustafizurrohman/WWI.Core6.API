using FluentValidation;
using Microsoft.OpenApi.Models;
using System;

namespace WWI.Core3.Models.Validators
{


#pragma warning disable CS1584 // XML comment has syntactically incorrect cref attribute

#pragma warning disable CS1658 // Warning is overriding an error
    /// <summary>
    /// Class OpenApiInfoValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Microsoft.OpenApi.Models.OpenApiInfo}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Microsoft.OpenApi.Models.OpenApiInfo}" />
    public class OpenApiInfoValidator : AbstractValidator<OpenApiInfo>
#pragma warning restore CS1658 // Warning is overriding an error
#pragma warning restore CS1584 // XML comment has syntactically incorrect cref attribute
    {
        /// <summary>
        /// Values the tuple.
        /// </summary>
        /// <returns>OpenApiInfo.</returns>
        public OpenApiInfoValidator()
        {
            RuleFor(openApiInfo => openApiInfo.Version)
                .NotEmpty()
                .NotNull()
                .Must(IsValidVersion)
                .WithMessage("Invalid version number.");

            RuleFor(openApiInfo => openApiInfo.Title)
                .NotEmpty()
                .NotNull();

            RuleFor(openApiInfo => openApiInfo.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(openApiInfo => openApiInfo.TermsOfService)
                .NotEmpty()
                .NotNull();

            RuleFor(openApiInfo => openApiInfo.Contact)
                .NotNull()
                .WithMessage("Contact information must be specified");

            RuleFor(openApiInfo => openApiInfo.Contact.Name)
                .NotEmpty()
                .NotNull();

            RuleFor(openApiInfo => openApiInfo.Contact.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();
        }

        private static bool IsValidVersion(string version)
        {
            try
            {
                return new Version(version).ToString() == version;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
