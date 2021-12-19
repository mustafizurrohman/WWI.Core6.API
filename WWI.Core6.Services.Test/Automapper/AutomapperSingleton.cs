using AutoMapper;
using WWI.Core6.Core.AutoMapper;

namespace WWI.Core6.Services.Tests.Automapper
{
    public static class AutomapperSingleton
    {
        /// <summary>
        /// The automatic mapper
        /// </summary>
        private static IMapper _autoMapper;

        public static IMapper AutoMapper
        {
            get
            {
                if (_autoMapper != null) return _autoMapper;

                var mappingConfig = new MapperConfiguration(mc =>
                {
                    // mc.AddProfile(new MappingProfile());
                    mc.AddProfile<MappingProfile>();
                });


                IMapper mapper = mappingConfig.CreateMapper();
                _autoMapper = mapper;


                return _autoMapper;

            }
        }

    }
}
