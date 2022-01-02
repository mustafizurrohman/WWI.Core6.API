namespace WWI.Core6.Services.MediatR.Queries;

public record GetHospitalInformationQuery(int HospitalID) : IRequest<HospitalInformation>;