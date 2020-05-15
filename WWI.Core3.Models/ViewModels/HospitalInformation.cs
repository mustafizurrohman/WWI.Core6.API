using System.Collections.Generic;

namespace WWI.Core3.Models.ViewModels
{

    /// <summary>
    /// 
    /// </summary>
    public class HospitalInformation
    {
        /// <summary>
        /// 
        /// </summary>
        public int HospitalID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Specialities { get; set; }
    }
}
