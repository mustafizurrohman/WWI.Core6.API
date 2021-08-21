using FluentValidation;
using Microsoft.OpenApi.Models;
using System;

namespace WWI.Core3.Models.Validators
{
    /// <summary>
    /// Class OpenApiInfoValidator.
    /// </summary>
    public class OpenApiInfoValidator : AbstractValidator<OpenApiInfo>
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
