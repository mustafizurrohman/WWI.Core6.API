// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 09-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-17-2020
// ***********************************************************************
// <copyright file="SharedService.cs" company="WWI.Core6.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WWI.Core6.Services.Interfaces;
using WWI.Core6.Services.Services.Base;

namespace WWI.Core6.Services.Services.Shared;

/// <summary>
/// Class SharedService.
/// Implements the <see cref="ISharedService" />
/// </summary>
/// <seealso cref="ISharedService" />
public class SharedService : BaseService, ISharedService
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationServices"></param>
    public SharedService(IApplicationServices applicationServices) : base(applicationServices)
    {
    }

    /// <summary>
    /// Gets the hospital information.
    /// </summary>
    /// <returns>IQueryable&lt;HospitalInformation&gt;.</returns>
    public IQueryable<HospitalInformation> GetHospitalInformation()
    {
        return DbContext.Hospitals
            .ProjectTo<HospitalInformation>(AutoMapper.ConfigurationProvider)
            .AsQueryable();
    }

    /// <summary>
    /// Get advanced information about hospital
    /// </summary>
    /// <returns></returns>
    public IQueryable<AdvancedHospitalInformation> GetAdvancedHospitalInformation()
    {
        return DbContext.Hospitals
            .ProjectTo<AdvancedHospitalInformation>(AutoMapper.ConfigurationProvider)
            .AsQueryable();
    }

    /// <summary>
    /// Gets information about a doctor
    /// </summary>
    /// <returns></returns>
    public IQueryable<DoctorInfo> GetInformationAboutDoctor()
    {
        return DbContext.Doctors
            .ProjectTo<DoctorInfo>(AutoMapper.ConfigurationProvider)
            .AsQueryable();
    }

    [SuppressMessage("ReSharper", "SpecifyStringComparison")]
    public bool BeUniqueName(string firstName, string middleName, string lastName, int specialityID)
    {
        var nameIsPresent = DbContext.Doctors
            .Where(doc => doc.Firstname.ToLower() == firstName.ToLower())
            .Where(doc => doc.Middlename.ToLower() == middleName.ToLower())
            .Where(doc => doc.Lastname.ToLower() == lastName.ToLower())
            .Any(doc => doc.SpecialityID == specialityID);

        return !nameIsPresent;
    }

    [SuppressMessage("ReSharper", "SpecifyStringComparison")]
    public async Task<bool> BeUniqueNameAsync(string firstName, string middleName, string lastName, int specialityID)
    {
        var nameIsPresent = await DbContext.Doctors
            .Where(doc => doc.Firstname.ToLower() == firstName.ToLower())
            .Where(doc => doc.Middlename.ToLower() == middleName.ToLower())
            .Where(doc => doc.Lastname.ToLower() == lastName.ToLower())
            .AnyAsync(doc => doc.SpecialityID == specialityID);

        return !nameIsPresent;
    }
}