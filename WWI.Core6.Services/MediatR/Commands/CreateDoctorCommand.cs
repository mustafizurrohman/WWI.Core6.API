using JetBrains.Annotations;

namespace WWI.Core6.Services.MediatR.Commands;

public class CreateDoctorCommand : IRequest<DoctorInfo>
{
    [UsedImplicitly] 
    public string Firstname { get; init; }
    [UsedImplicitly] 
    public string Middlename { get; init; }
    [UsedImplicitly] 
    public string Lastname { get; init; }
    [UsedImplicitly] 
    public int SpecialityID { get; init; }
}