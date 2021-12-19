using AutoMapper;
using WWI.Core6.Models.DbContext;
using WWI.Core6.Services.ServiceCollection;

namespace WWI.Core6.Services.MediatR.Handlers
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
            DbContext = Guard.Against.Null(applicationServices.DbContext, nameof(applicationServices.DbContext));
            AutoMapper = Guard.Against.Null(applicationServices.AutoMapper, nameof(applicationServices.AutoMapper));
        }


    }
}
