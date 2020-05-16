// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 05-16-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="SpecialityInformation.cs" company="WWI.Core3.Models">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace WWI.Core3.Models.ViewModels
{

    /// <summary>
    /// Class SpecialityInformation.
    /// </summary>
    public class SpecialityInformation
    {

        /// <summary>
        /// Gets or sets the name of the department.
        /// </summary>
        /// <value>The name of the department.</value>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Gets or sets the doctor list.
        /// </summary>
        /// <value>The doctor list.</value>
        public List<string> DoctorList { get; set; }

    }


}
