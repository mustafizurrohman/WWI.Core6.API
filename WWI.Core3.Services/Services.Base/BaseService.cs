using AutoMapper;
using WWI.Core3.Models.DbContext;

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
        /// <param name="docAppointmentContext">The database context.</param>
        protected BaseService(DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        /// <param name="autoMapper"></param>
        protected BaseService(DocAppointmentContext docAppointmentContext, IMapper autoMapper)
        {
            DbContext = docAppointmentContext;
            AutoMapper = autoMapper;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="docAppointmentContext">The database context.</param>
        /// <param name="autoMapper"></param>
        protected BaseService(IMapper autoMapper, DocAppointmentContext docAppointmentContext)
        {
            DbContext = docAppointmentContext;
            AutoMapper = autoMapper;
        }

    }
}
