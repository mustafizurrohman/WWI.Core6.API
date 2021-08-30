using FluentValidation;
using System.Linq;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Services.MediatR.Commands;

namespace WWI.Core3.Services.Validation
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        private DocAppointmentContext DbContext { get; }

        public CreateDoctorCommandValidator(DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
            SetValidationRules();
        }

        private void SetValidationRules()
        {
            RuleFor(prop => prop.Firstname)
                .NotEmpty()
                .NotNull()
                .Must(BeValidName);

            RuleFor(prop => prop.Middlename)
                .Must(BeValidName);

            RuleFor(prop => prop.Lastname)
                .NotEmpty()
                .NotNull()
                .Must(BeValidName);

            RuleFor(prop => prop.SpecialityID)
                .NotEmpty()
                .NotNull()
                .Must(BeValidSpecialityID);

        }

        private bool BeValidSpecialityID(int specialityID)
        {
            return DbContext.Specialities.Any(s => s.SpecialtyID == specialityID);
        }
        
        private bool BeValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return true;

            return !name.Any(char.IsDigit);
        }

    }
}
