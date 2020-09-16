using AutoMapper;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.Services.ServiceCollection
{
    /// <summary>
    /// Interface IApplicationServices
    /// </summary>
    public interface IApplicationServices
    {
        /// <summary>
        /// The database context
        /// </summary>
        /// <value>The database context.</value>
        DocAppointmentContext DbContext { get; }

        /// <summary>
        /// AutoMapper
        /// </summary>
        /// <value>The automatic mapper.</value>
        IMapper AutoMapper { get; }
    }
}