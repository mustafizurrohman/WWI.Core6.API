using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.MediatR.Commands;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
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
