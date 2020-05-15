using AutoMapper;
using WWI.Core3.Models.DbContext;

namespace WWI.Core3.Services.ServiceCollection
{
    public class ApplicationServices
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
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public ApplicationServices(DocAppointmentContext dbContext,
            IMapper mapper)
        {
            this.DbContext = dbContext;
            this.AutoMapper = mapper;
        }
    }
}
