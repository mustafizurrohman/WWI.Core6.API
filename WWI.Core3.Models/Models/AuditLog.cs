// ***********************************************************************
// Assembly         : WWI.Core3.Models
// Author           : Mustafizur Rohman
// Created          : 06-28-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 06-28-2020
// ***********************************************************************
// <copyright file="AuditLog.cs" company="WWI.Core3.Models">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace WWI.Core3.Models.Models
{
    /// <summary>
    /// Class AuditLog.
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class AuditLog
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>The date time.</value>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Gets or sets the key values.
        /// </summary>
        /// <value>The key values.</value>
        public string KeyValues { get; set; }

        /// <summary>
        /// Creates new values.
        /// </summary>
        /// <value>The new values.</value>
        public string NewValues { get; set; }


        /// <summary>Gets or sets the old values.</summary>
        /// <value>The old values.</value>
        public string OldValues { get; set; }

    }
}
