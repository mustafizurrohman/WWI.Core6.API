﻿using WWI.Core6.Models.ViewModels;

namespace WWI.Core6.Services.MediatR.Queries
{
    public class GetAllDoctorsQuery : IRequest<List<Dropdown>>
    {
        public GetAllDoctorsQuery()
        {
        }
    }
}