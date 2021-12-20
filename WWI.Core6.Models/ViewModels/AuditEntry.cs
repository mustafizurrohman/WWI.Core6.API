// ***********************************************************************
// Assembly         : WWI.Core6.Models
// Author           : Mustafizur Rohman
// Created          : 06-28-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 06-28-2020
// ***********************************************************************
// <copyright file="AuditEntry.cs" company="WWI.Core6.Models">
//     Copyright (c) Personal. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using WWI.Core6.Models.Models;

// ReSharper disable MemberCanBePrivate.Global

namespace WWI.Core6.Models.ViewModels
{
    /// <summary>
    /// Class AuditEntry.
    /// </summary>
    public class AuditEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditEntry"/> class.
        /// </summary>
        /// <param name="entry">The entry.</param>
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }

        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <value>The entry.</value>
        public EntityEntry Entry { get; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        public string TableName { get; set; }

        /// <summary>
        /// Gets the key values.
        /// </summary>
        /// <value>The key values.</value>
        public Dictionary<string, object> KeyValues { get; } = new();

        /// <summary>
        /// Gets the old values.
        /// </summary>
        /// <value>The old values.</value>
        public Dictionary<string, object> OldValues { get; } = new();

        /// <summary>
        /// Creates new values.
        /// </summary>
        /// <value>The new values.</value>
        public Dictionary<string, object> NewValues { get; } = new();

        /// <summary>
        /// Gets the temporary properties.
        /// </summary>
        /// <value>The temporary properties.</value>
        public List<PropertyEntry> TemporaryProperties { get; } = new();

        /// <summary>
        /// Gets a value indicating whether this instance has temporary properties.
        /// </summary>
        /// <value><c>true</c> if this instance has temporary properties; otherwise, <c>false</c>.</value>
        public bool HasTemporaryProperties => TemporaryProperties.Any();

        /// <summary>
        /// Converts to audit.
        /// </summary>
        /// <returns>AuditLog.</returns>
        public AuditLog ToAudit()
        {
            var audit = new AuditLog
            {
                TableName = TableName,
                DateTime = DateTime.UtcNow,
                KeyValues = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues)
            };

            return audit;
        }
    }
}
