﻿using Microsoft.EntityFrameworkCore;
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

    }
        
    private Task<bool> BeValidSpecialityID(int specialityID, CancellationToken cancellationToken)
    {
        return DbContext.Specialities.AnyAsync(s => s.SpecialtyID == specialityID, cancellationToken);
    }
}