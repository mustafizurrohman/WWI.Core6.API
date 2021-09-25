﻿using MediatR;
using WWI.Core3.Models.ViewModels;

namespace WWI.Core3.Services.MediatR.Queries
{
    public class GetSpecialityInformationByIDQuery : IRequest<Dropdown>
    {
        public int SpecialityID { get; }

        public GetSpecialityInformationByIDQuery(int specialityID)
        {
            SpecialityID = specialityID;
        }
    }
}