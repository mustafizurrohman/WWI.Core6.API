// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-19-2020
// ***********************************************************************
// <copyright file="MappingProfile.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using System.Linq;
using WWI.Core3.Models.Models;
using WWI.Core3.Models.ViewModels;
using WWI.Core3.Models.ViewModels.Dropdown;

namespace WWI.Core3.Core.AutoMapper
{

    /// <summary>
    /// Class MappingProfile.
    /// Implements the <see cref="Profile" />
    /// </summary>
    /// <seealso cref="Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile" /> class.
        /// </summary>
        public MappingProfile()
        {

            CreateMappings();

        }

        /// <summary>
        /// Creates the mappings.
        /// </summary>
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

            // Hospital -> AdvancedHospitalInformation
            CreateMap<Hospital, AdvancedHospitalInformation>()
                .ForMember(dst => dst.HospitalName,
                    src => src.MapFrom(hos => hos.Name))
                .ForMember(dst => dst.Address,
                    src => src.MapFrom(hos => hos.Address))
                .ForMember(dst => dst.Specialities,
                    src => src.MapFrom(hos => hos.Specialities.Select(s => s.Speciality)));

            // Speciality -> SpecialityInformation
            CreateMap<Speciality, SpecialityInformation>()
                .ForMember(dst => dst.SpecialtyID,
                    src => src.MapFrom(s => s.SpecialtyID))
                .ForMember(dst => dst.SpecialityName,
                    src => src.MapFrom(s => s.Name))
                .ForMember(dst => dst.DoctorList,
                    src => src.MapFrom(s => s.Doctors.Select(d => d.FullName)));

            // Hospital -> HospitalDoctorInformation
            CreateMap<Hospital, HospitalDoctorInformation>()
                .ForMember(dst => dst.HospitalID,
                    src => src.MapFrom(hos => hos.HospitalID))
                .ForMember(dst => dst.HospitalName,
                    src => src.MapFrom(hos => hos.Name))
                .ForMember(dst => dst.Doctors,
                    src => src.MapFrom(hos => hos.Doctors.Select(d => d.Doctor)));

            // Doctor -> DoctorInfo
            CreateMap<Doctor, DoctorInfo>()
                .ForMember(dst => dst.FullName,
                    src => src.MapFrom(doc => doc.FullName))
                .ForMember(dst => dst.SpecialityName,
                    src => src.MapFrom(doc => doc.Speciality.Name));

            // Ideally this should be automatic based on AutoMapper convention?
            // Speciality -> SpecialityDropdown
            CreateMap<Speciality, SpecialityDropdown>();

            // Hospital -> HospitalDropdown
            CreateMap<Hospital, HospitalDropdown>();

            // Doctor -> DoctorDropdown
            CreateMap<Doctor, DoctorDropdown>();

        }

    }
}
