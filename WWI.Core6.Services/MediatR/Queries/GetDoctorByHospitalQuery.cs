namespace WWI.Core6.Services.MediatR.Queries;

public record GetDoctorByHospitalQuery(int HospitalID) : IRequest<List<Dropdown>>;
