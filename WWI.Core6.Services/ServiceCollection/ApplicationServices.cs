// ***********************************************************************
// Assembly         : WWI.Core6.Services
// Author           : Mustafizur Rohman
// Created          : 05-15-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-15-2020
// ***********************************************************************
// <copyright file="ApplicationServices.cs" company="WWI.Core6.Services">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using WWI.Core6.Models.DbContext;

namespace WWI.Core6.Services.ServiceCollection;

/// <summary>
/// Class ApplicationServices.
/// </summary>
public class ApplicationServices : IApplicationServices
{
    /// <summary>
    /// The database context
    /// </summary>
    /// <value>The database context.</value>
    public DocAppointmentContext DbContext { get; }

    /// <summary>
    /// AutoMapper
    /// </summary>
    /// <value>The automatic mapper.</value>
    public IMapper AutoMapper { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ApplicationServices"/> class.
    /// </summary>
    /// <param name="dbContext">The database context.</param>
    /// <param name="mapper">The mapper.</param>
    public ApplicationServices(DocAppointmentContext dbContext, IMapper mapper)
    {
        DbContext = Guard.Against.Null(dbContext, nameof(dbContext));
        AutoMapper = Guard.Against.Null(mapper, nameof(mapper));
    }
}