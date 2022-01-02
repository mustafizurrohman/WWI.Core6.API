namespace WWI.Core6.Services.MediatR.Queries;

public record GetAdvancedHospitalInformationQuery(int HospitalID) : IRequest<AdvancedHospitalInformation>;
