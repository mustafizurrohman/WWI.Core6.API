namespace WWI.Core6.Services.MediatR.Queries;

public record GetDoctorsBySpecialityQuery(int SpecialityID) : IRequest<List<Dropdown>>;