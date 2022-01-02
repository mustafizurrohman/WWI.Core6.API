namespace WWI.Core6.Services.MediatR.Queries;

public record GetSpecialityInfoForHospitalQuery(int HospitalID, int SpecialityID) : IRequest<SpecialityInformation>;