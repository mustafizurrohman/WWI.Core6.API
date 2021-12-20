// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 08-29-2021
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 08-29-2021
// ***********************************************************************
// <copyright file="HospitalSpecialityConfiguration.cs" company="WWI.Core6.Models">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WWI.Core6.Models.Models;

namespace WWI.Core6.Models.EntityConfigurations
{
    /// <summary>
    /// Class HospitalSpecialityConfiguration.
    /// Implements the <see cref="HospitalSpeciality" />
    /// </summary>
    /// <seealso cref="HospitalSpeciality" />
    internal class HospitalSpecialityConfiguration : IEntityTypeConfiguration<HospitalSpeciality>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<HospitalSpeciality> builder)
        {
            builder.HasOne(hs => hs.Hospital)
                .WithMany(h => h.Specialities)
                .HasForeignKey(hs => hs.HospitalID);

            builder.HasOne(hs => hs.Speciality)
                .WithMany(h => h.Hospitals)
                .HasForeignKey(hs => hs.SpecialtyID);
        }
    }
}
