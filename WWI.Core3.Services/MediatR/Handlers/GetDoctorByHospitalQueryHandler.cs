using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetDoctorByHospitalQueryHandler : HandlerBase, IRequestHandler<GetDoctorByHospitalQuery, List<Dropdown>>
    {
        public GetDoctorByHospitalQueryHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {
            
        }

        public async Task<List<Dropdown>> Handle(GetDoctorByHospitalQuery request, CancellationToken cancellationToken)
        {
            var doctorsForHospital = await DbContext.Hospitals
                .Include(hos => hos.Doctors)
                .ThenInclude(hd => hd.Doctor)
                .Where(hos => hos.HospitalID == request.HospitalID)
                .SelectMany(hos => hos.Doctors)
                .Select(hd => hd.Doctor)
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            doctorsForHospital = doctorsForHospital
                .OrderBy(ds => ds.DisplayValue)
                .ToList();

            return doctorsForHospital;
        }
    }
}
