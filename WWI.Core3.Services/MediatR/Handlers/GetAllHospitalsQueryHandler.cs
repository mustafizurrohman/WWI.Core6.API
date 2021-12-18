using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WWI.Core3.Services.MediatR.Queries;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class GetAllHospitalsQueryHandler : HandlerBase, IRequestHandler<GetAllHospitalsQuery, List<Dropdown>>
    {
        public GetAllHospitalsQueryHandler(IApplicationServices applicationServices)
            : base(applicationServices)
        {

        }

        public async Task<List<Dropdown>> Handle(GetAllHospitalsQuery request, CancellationToken cancellationToken)
        {
            var hospitals = await DbContext.Hospitals
                .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
                .OrderBy(hos => hos.DisplayValue)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return hospitals;
        }
    }
}
