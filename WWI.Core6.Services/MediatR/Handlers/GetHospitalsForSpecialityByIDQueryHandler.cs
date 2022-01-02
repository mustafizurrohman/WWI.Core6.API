namespace WWI.Core6.Services.MediatR.Handlers;

public class GetHospitalsForSpecialityByIDQueryHandler : HandlerBase, IRequestHandler<GetHospitalsForSpecialityByIDQuery, List<Dropdown>>
{
    public GetHospitalsForSpecialityByIDQueryHandler(IApplicationServices applicationServices)
        : base(applicationServices)
    {
            
    }


    public async Task<List<Dropdown>> Handle(GetHospitalsForSpecialityByIDQuery request, CancellationToken cancellationToken)
    {
        var hospitals = await DbContext.Specialities
            .Include(s => s.Hospitals)
            .Where(s => s.SpecialtyID == request.SpecialityID)
            .SelectMany(s => s.Hospitals)
            .Select(hs => hs.Hospital)
            .ProjectTo<Dropdown>(AutoMapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return hospitals;
    }
}