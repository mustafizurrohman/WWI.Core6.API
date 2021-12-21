using Microsoft.EntityFrameworkCore;
using WWI.Core6.Models.Models;
using WWI.Core6.Services.MediatR.Commands;

namespace WWI.Core6.Services.MediatR.Handlers
{
    public class CreateDoctorCommandHandler : HandlerBase, IRequestHandler<CreateDoctorCommand, DoctorInfo>
    {
        public CreateDoctorCommandHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {

        }

        public async Task<DoctorInfo> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor()
            {
                DoctorID =  0,
                Firstname = request.Firstname,
                Middlename = request.Middlename,
                Lastname = request.Lastname, 
                Speciality = await DbContext.Specialities.FindAsync(request.SpecialityID, cancellationToken)
            };
            
            await DbContext.Doctors.AddAsync(doctor, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            var doctorInfo = await DbContext
                .Doctors
                .ProjectTo<DoctorInfo>(AutoMapper.ConfigurationProvider)
                .FirstOrDefaultAsync(doc => doc.DoctorID == doctor.DoctorID, cancellationToken);

            return doctorInfo;
        }
    }
}
