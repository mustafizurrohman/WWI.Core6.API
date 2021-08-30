using AutoMapper;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.MediatR.Handlers
{
    public class HandlerBase
    {
        /// <summary>
        /// The database context
        /// </summary>
        /// <value>The database context.</value>
        protected DocAppointmentContext DbContext { get; }

        /// <summary>
        /// AutoMapper
        /// </summary>
        /// <value>The automatic mapper.</value>
        protected IMapper AutoMapper { get; }


        /// <summary>
        /// Initializes a new instance of the <see cref="HandlerBase"/> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        protected HandlerBase(IApplicationServices applicationServices)
        {
            DbContext = applicationServices.DbContext;
            AutoMapper = applicationServices.AutoMapper;
        }


    }
}
