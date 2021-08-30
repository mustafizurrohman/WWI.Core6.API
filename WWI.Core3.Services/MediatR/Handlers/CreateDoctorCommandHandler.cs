using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
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

        public Task<DoctorInfo> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
