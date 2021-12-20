// ***********************************************************************
// Assembly         : WWI.Core6.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="DictionaryExtensions.cs" company="WWI.Core6.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace WWI.Core6.Core.ExtensionMethods
{
    /// <summary>
    /// Extension Methods for Dictionary
    /// </summary>
    public static class DictionaryExtensions
    {

        /// <summary>
        /// Gets the value or default.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>T2.</returns>
        public static T2 GetValueOrDefault<T1, T2>(this Dictionary<T1, T2> dictionary, T1 key, T2 defaultValue = default)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
        }


    }
}
