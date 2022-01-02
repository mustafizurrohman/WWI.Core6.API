namespace WWI.Core6.Services.MediatR.Queries;

public record GetSpecialitiesDropdownForHospitalQuery(int HospitalID) : IRequest<List<Dropdown>>;