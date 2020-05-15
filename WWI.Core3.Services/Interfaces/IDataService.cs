using System.Threading.Tasks;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        Task<HospitalInformation> GetHospitalInformationByIDAsync(int hospitalID);

    }
}