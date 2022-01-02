using WWI.Core6.Models.Models;
using WWI.Core6.Services.MediatR.Commands;

namespace WWI.Core6.Services.MediatR.Handlers;

public class CreateDoctorCommandHandler : HandlerBase, IRequestHandler<CreateDoctorCommand, DoctorInfo>
{
    private ISharedService SharedService { get; }

    public CreateDoctorCommandHandler(IApplicationServices applicationServices, ISharedService sharedService)
        : base(applicationServices)
    {
        SharedService  = sharedService;
    }

    public async Task<DoctorInfo> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        var doctor = new Doctor
        {
            DoctorID =  0,
            Firstname = request.Firstname,
            Middlename = request.Middlename,
            Lastname = request.Lastname, 
            Speciality = await DbContext.Specialities.FindAsync(request.SpecialityID)
        };
            
        await DbContext.Doctors.AddAsync(doctor, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        var doctorInfo = await SharedService.GetInformationAboutDoctor()
            .Where(doc => doc.DoctorID == doctor.DoctorID)
            .SingleAsync(cancellationToken);

        return doctorInfo;
    }
}