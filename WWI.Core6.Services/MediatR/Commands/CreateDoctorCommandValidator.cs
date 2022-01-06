using WWI.Core6.Models.DbContext;
using WWI.Core6.Models.Validators.Custom;

namespace WWI.Core6.Services.MediatR.Commands;

public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
{
    private DocAppointmentContext DbContext { get; }
    private ISharedService SharedService { get; }

    // Dependency Injection also for Input Validation!
    public CreateDoctorCommandValidator(DocAppointmentContext docAppointmentContext, ISharedService sharedService)
    {
        DbContext = docAppointmentContext;
        SharedService = sharedService;
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

        RuleFor(prop => prop)
            .MustAsync(async (prop, _) => await SharedService.IsUniqueDoctorNameAsync(prop.Firstname, prop.Middlename, prop.Lastname, prop.SpecialityID))
            .WithMessage("Doctor is already present in database");

    }
        
    private Task<bool> BeValidSpecialityID(int specialityID, CancellationToken cancellationToken)
    {
        return DbContext.Specialities.AnyAsync(s => s.SpecialtyID == specialityID, cancellationToken);
    }


}