// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 09-25-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-26-2021
// ***********************************************************************
// <copyright file="IFakeDataGeneratorService.cs" company="WWI.Core6.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using WWI.Core6.Models.Models;

namespace WWI.Core6.Services.Interfaces;

/// <summary>
/// Interface IFakeDataGeneratorService
/// </summary>
public interface IFakeDataGeneratorService
{
    /// <summary>
    /// Generates the fake doctors.
    /// </summary>
    /// <param name="num">The number.</param>
    /// <returns>IEnumerable&lt;Doctor&gt;.</returns>
    IEnumerable<Doctor> GenerateFakeDoctors(int num);

    /// <summary>
    /// Generates the fake address.
    /// </summary>
    /// <param name="num">The number.</param>
    /// <returns>IEnumerable&lt;Address&gt;.</returns>
    IEnumerable<Address> GenerateFakeAddress(int num);
        
    /// <summary>
    /// Generates the fake hospitals.
    /// </summary>
    /// <param name="num">The number.</param>
    /// <returns>IEnumerable&lt;Hospital&gt;.</returns>
    IEnumerable<Hospital> GenerateFakeHospitals(int num);
        
    /// <summary>
    /// Generates the fake specialities.
    /// </summary>
    /// <param name="num">The number.</param>
    /// <returns>IEnumerable&lt;Speciality&gt;.</returns>
    IEnumerable<Speciality> GenerateFakeSpecialities(int num);
}