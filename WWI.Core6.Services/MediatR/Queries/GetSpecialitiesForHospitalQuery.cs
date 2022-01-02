namespace WWI.Core6.Services.MediatR.Queries;

public record GetSpecialitiesForHospitalQuery(int HospitalID) : IRequest<List<SpecialityInformation>>;