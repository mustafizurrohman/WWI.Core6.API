// ***********************************************************************
// Assembly         : WWI.Core3.Services
// Author           : Mustafizur Rohman
// Created          : 09-25-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 09-25-2021
// ***********************************************************************
// <copyright file="FakeDataGeneratorService.cs" company="WWI.Core3.Services">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Ardalis.GuardClauses;
using Bogus;
using System.Collections.Generic;
using WWI.Core3.Models.Models;
using WWI.Core3.Services.Interfaces;
using WWI.Core3.Services.ServiceCollection;
using WWI.Core3.Services.Services.Base;

namespace WWI.Core3.Services.Services
{

    /// <summary>
    /// Class FakeDataGeneratorService.
    /// Implements the <see cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// Implements the <see cref="WWI.Core3.Services.Interfaces.IFakeDataGeneratorService" />
    /// </summary>
    /// <seealso cref="WWI.Core3.Services.Services.Base.BaseService" />
    /// <seealso cref="WWI.Core3.Services.Interfaces.IFakeDataGeneratorService" />
    public class FakeDataGeneratorService : BaseService, IFakeDataGeneratorService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDataGeneratorService"/> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        public FakeDataGeneratorService(IApplicationServices applicationServices)
            : base(applicationServices)
        {
            
        }


        /// <summary>
        /// Generates the fake doctors.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IEnumerable&lt;Doctor&gt;.</returns>
        public IEnumerable<Doctor> GenerateFakeDoctors(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));
            return GetDoctorFaker().Generate(num);
        }

        /// <summary>
        /// Generates the fake address.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IEnumerable&lt;Address&gt;.</returns>
        public IEnumerable<Address> GenerateFakeAddress(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));
            return GetAddressFaker().Generate(num);
        }

        /// <summary>
        /// Generates the fake hospitals.
        /// </summary>
        /// <param name="num">The number.</param>
        /// <returns>IEnumerable&lt;Hospital&gt;.</returns>
        public IEnumerable<Hospital> GenerateFakeHospitals(int num)
        {
            num = Guard.Against.NegativeOrZero(num, nameof(num));
            return GetHospitalFakar().Generate(num);
        }

        /// <summary>
        /// Gets the address faker.
        /// </summary>
        /// <returns>Faker&lt;Address&gt;.</returns>
        private Faker<Address> GetAddressFaker()
        {
            var addressFaker = new Faker<Address>()
                .StrictMode(false)
                .RuleFor(adr => adr.AddressID, fake => fake.IndexFaker)
                .RuleFor(adr => adr.Street, fake => fake.Address.StreetAddress())
                .RuleFor(adr => adr.District, fake => fake.Address.CityPrefix())
                .RuleFor(adr => adr.State, fake => fake.Address.State())
                .RuleFor(adr => adr.Country, fake => fake.Address.Country())
                .RuleFor(adr => adr.PIN, fake => fake.Address.ZipCode());

            return addressFaker;
        }

        /// <summary>
        /// Gets the hospital fakar.
        /// </summary>
        /// <returns>Faker&lt;Hospital&gt;.</returns>
        private Faker<Hospital> GetHospitalFakar()
        {
            var hospitalFaker = new Faker<Hospital>()
                .StrictMode(false)
                .RuleFor(hos => hos.HospitalID, fake => fake.IndexFaker)
                .RuleFor(hos => hos.Name, fake => fake.Company.CompanyName())
                .RuleFor(hos => hos.Address, GetAddressFaker());

            return hospitalFaker;
        }

        /// <summary>
        /// Gets the doctor faker.
        /// </summary>
        /// <returns>Faker&lt;Doctor&gt;.</returns>
        private Faker<Doctor> GetDoctorFaker()
        {
            var doctorFaker = new Faker<Doctor>()
                .StrictMode(false)
                .RuleFor(doc => doc.Firstname, fake => fake.Name.FirstName())
                .RuleFor(doc => doc.Lastname, fake => fake.Name.LastName())
                .RuleFor(doc => doc.SpecialityID, fake => fake.UniqueIndex)
                .RuleFor(doc => doc.Middlename, fake => string.Empty);

            return doctorFaker;
        }

    }
}
