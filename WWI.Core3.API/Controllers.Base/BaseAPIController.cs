﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WWI.Core3.API.ActionFilters;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.API.Controllers.Base
{

    /// <summary>
    /// Base API Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Benchmark]
    [Route("[controller]")]
    [Produces("application/json")]
    public class BaseAPIController : ControllerBase
    {

        /// <summary>
        /// The database context
        /// </summary>
        public DocAppointmentContext DbContext { get; }

        /// <summary>
        /// AutoMapper
        /// </summary>
        public IMapper AutoMapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        public BaseAPIController(DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        /// <param name="autoMapper"></param>
        public BaseAPIController(DocAppointmentContext docAppointmentContext, IMapper autoMapper)
        {
            DbContext = docAppointmentContext;
            AutoMapper = autoMapper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAPIController"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        /// <param name="autoMapper"></param>
        public BaseAPIController(IMapper autoMapper, DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
            AutoMapper = autoMapper;
        }

    }
}
