﻿// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 08-29-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 08-29-2021
// ***********************************************************************
// <copyright file="HospitalDoctorConfiguration.cs" company="WWI.Core3.Models">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WWI.Core3.Models.Models;

namespace WWI.Core3.Models.EntityConfigurations
{
    /// <summary>
    /// Class HospitalDoctorConfiguration.
    /// Implements the <see cref="HospitalDoctor" />
    /// </summary>
    /// <seealso cref="HospitalDoctor" />
    internal class HospitalDoctorConfiguration : IEntityTypeConfiguration<HospitalDoctor>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<HospitalDoctor> builder)
        {
            builder.HasOne(hd => hd.Hospital)
                .WithMany(hospital => hospital.Doctors)
                .HasForeignKey(hospital => hospital.HospitalID);

            builder.HasOne(hd => hd.Doctor)
                .WithMany(doctor => doctor.Hospitals)
                .HasForeignKey(doctor => doctor.DoctorID);
        }
    }
}
