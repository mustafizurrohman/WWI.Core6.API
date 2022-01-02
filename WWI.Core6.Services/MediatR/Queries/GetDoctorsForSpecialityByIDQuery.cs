namespace WWI.Core6.Services.MediatR.Queries;

public record GetDoctorsForSpecialityByIDQuery(int SpecialityID) : IRequest<List<Dropdown>>;