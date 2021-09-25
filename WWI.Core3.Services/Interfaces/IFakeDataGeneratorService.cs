using System.Collections.Generic;
using WWI.Core3.Models.Models;

namespace WWI.Core3.Services.Interfaces
{
    public interface IFakeDataGeneratorService
    {
        IEnumerable<Doctor> GenerateFakeDoctors(int num);
        IEnumerable<Address> GenerateFakeAddress(int num);
        IEnumerable<Hospital> GenerateFakeHospitals(int num);
        IEnumerable<Speciality> GenerateFakeSpecialities(int num);
    }
}