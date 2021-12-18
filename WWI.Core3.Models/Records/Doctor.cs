// public readonly record struct Doctor(double X, double Y, double Z);
namespace WWI.Core6.Models.Records;

/// <summary>
/// 
/// </summary>
/// <param name="Firstname"></param>
/// <param name="Lastname"></param>
/// <param name="FullName"></param>
/// <param name="Speciality"></param>
/// <param name="Hospitals"></param>
public record DoctorRecord(
    string Firstname,
    string Lastname,
    string FullName,
    string Speciality,
    List<string> Hospitals
);