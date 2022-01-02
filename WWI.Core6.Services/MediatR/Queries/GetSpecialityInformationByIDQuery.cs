namespace WWI.Core6.Services.MediatR.Queries;

public record GetSpecialityInformationByIDQuery(int SpecialityID) : IRequest<Dropdown>;


