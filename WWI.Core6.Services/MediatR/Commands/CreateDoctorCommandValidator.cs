using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WWI.Core6.Models.DbContext;
using WWI.Core6.Models.Validators.Custom;

namespace WWI.Core6.Services.MediatR.Commands;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    private DocAppointmentContext DbContext { get; }

    // Dependency Injection also for Input Validation!
    public CreateDoctorCommandValidator(DocAppointmentContext docAppointmentContext)
    {
        DbContext = docAppointmentContext;
        SetValidationRules();
    }

    private void SetValidationRules()
    {
        RuleFor(prop => prop.Firstname)
            .MustBeValidName();

        RuleFor(prop => prop.Middlename)
            .MustBeValidMiddleName();

        RuleFor(prop => prop.Lastname)
            .MustBeValidName();

        RuleFor(prop => prop.SpecialityID)
            .MustNotBeNullOrEmpty()
            .MustAsync(BeValidSpecialityID)
                .WithMessage("Invalid '{PropertyName}'.");

        RuleFor(prop => new { prop.Firstname, prop.Middlename, prop.Lastname, prop.SpecialityID })
            .Must(prop => BeUniqueName(prop.Firstname, prop.Middlename, prop.Lastname, prop.SpecialityID))
                .WithMessage("Doctor is already present in database");

    }
        
    private Task<bool> BeValidSpecialityID(int specialityID, CancellationToken cancellationToken)
    {
        return DbContext.Specialities.AnyAsync(s => s.SpecialtyID == specialityID, cancellationToken);
    }

    [SuppressMessage("ReSharper", "SpecifyStringComparison")]
    private bool BeUniqueName(string firstName, string middleName, string lastName, int specialityID)
    {
        var nameIsPresent = DbContext.Doctors
            .Where(doc => doc.Firstname.ToLower() == firstName.ToLower())
            .Where(doc => doc.Middlename.ToLower() == middleName.ToLower())
            .Where(doc => doc.Lastname.ToLower() == lastName.ToLower())
            .Any(doc => doc.SpecialityID == specialityID);

        return !nameIsPresent;

    }

}