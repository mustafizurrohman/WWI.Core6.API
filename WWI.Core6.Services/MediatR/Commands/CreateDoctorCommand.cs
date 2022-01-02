namespace WWI.Core6.Services.MediatR.Commands;

public record CreateDoctorCommand(string Firstname, string Middlename, string Lastname, int SpecialityID) : IRequest<DoctorInfo>;
