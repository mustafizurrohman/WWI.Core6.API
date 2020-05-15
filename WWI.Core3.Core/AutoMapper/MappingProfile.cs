using AutoMapper;
using System.Linq;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMappings();
        }

        public void CreateMappings()
        {

            // Hospital -> HospitalInformation
            CreateMap<Hospital, HospitalInformation>()
                .ForMember(dst => dst.HospitalID,
                    src => src.MapFrom(hos => hos.HospitalID))
                .ForMember(dst => dst.HospitalName,
                    src => src.MapFrom(hos => hos.Name))
                .ForMember(dst => dst.Specialities,
                    src => src.MapFrom(hos => hos.Specialities.Select(s => s.Speciality.Name).ToList()));

        }

    }
}
