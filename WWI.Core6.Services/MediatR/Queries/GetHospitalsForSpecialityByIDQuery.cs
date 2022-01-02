namespace WWI.Core6.Services.MediatR.Queries;

public record GetHospitalsForSpecialityByIDQuery(int SpecialityID) : IRequest<List<Dropdown>>;