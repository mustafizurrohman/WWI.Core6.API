namespace WWI.Core6.Services.MediatR.Queries;

public record GetDoctorsForHospitalQuery(int HospitalID) : IRequest<HospitalDoctorInformation>;