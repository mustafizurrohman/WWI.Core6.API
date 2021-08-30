using MediatR;
using System.Collections.Generic;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetAllDoctorsQuery : IRequest<List<Dropdown>>
    {
        public GetAllDoctorsQuery()
        {
            
        }

    }
}
