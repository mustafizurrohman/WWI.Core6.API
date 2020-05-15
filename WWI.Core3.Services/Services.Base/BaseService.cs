using AutoMapper;
using WWI.Core3.Models.DbContext;
using WWI.Core3.Services.ServiceCollection;

namespace WWI.Core3.Services.Services.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseService
    {
        /// <summary>
        /// The database context
        /// </summary>
        public DocAppointmentContext DbContext;

        /// <summary>
        /// AutoMapper
        /// </summary>
        public IMapper AutoMapper { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="applicationServices">The application services.</param>
        protected BaseService(ApplicationServices applicationServices)
        {
            DbContext = applicationServices.DbContext;
            AutoMapper = applicationServices.AutoMapper;
        }



    }
}
