// ***********************************************************************
// Assembly         : WWI.Core3.Core
// Author           : Mustafizur Rohman
// Created          : 05-08-2020
//
// Last Modified By : Mustafizur Rohman
// Last Modified On : 05-16-2020
// ***********************************************************************
// <copyright file="QueryableExtensions.cs" company="WWI.Core3.Core">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Reflection;
// ReSharper disable MemberCanBePrivate.Global

namespace WWI.Core3.Core.ExtensionMethods
{
    /// <summary>
    /// Extension methods for IQueryable
    /// </summary>
    public static class QueryableExtensions
    {

        /// <summary>
        /// Simple method to chunk a source IQueryable into smaller (more manageable) lists
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="source">The large IQueryable to split</param>
        /// <param name="chunkSize">The maximum number of items each subset should contain</param>
        /// <returns>An IEnumerable of the original source IEnumerable in bite size chunks</returns>
        public static IEnumerable<IQueryable<TSource>> Chunk<TSource>(this IQueryable<TSource> source, int chunkSize)
        {
            for (int i = 0; i < source.Count(); i += chunkSize)
                yield return source.Skip(i).Take(chunkSize);
        }

        /// <summary>
        /// Simple method to chunk a source IQueryable into smaller (more manageable) lists
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="source">The large IQueryable to split</param>
        /// <returns>IEnumerable&lt;IQueryable&lt;TSource&gt;&gt;.</returns>
        public static IEnumerable<IQueryable<TSource>> Chunk<TSource>(this IQueryable<TSource> source)
        {
            int chunkSize = (int)Math.Sqrt(source.Count());

            for (int i = 0; i < source.Count(); i += chunkSize)
                yield return source.Skip(i).Take(chunkSize);
        }

        /// <summary>
        /// Converts a IQueryable to equivalent SQL Statement.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query.</param>
        /// <returns>System.String.</returns>
        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            using var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
            var relationalCommandCache = enumerator.Private("_relationalCommandCache");
            var selectExpression = relationalCommandCache.Private<SelectExpression>("_selectExpression");
            var factory = relationalCommandCache.Private<IQuerySqlGeneratorFactory>("_querySqlGeneratorFactory");

            var sqlGenerator = factory.Create();
            var command = sqlGenerator.GetCommand(selectExpression);

            string sql = command.CommandText;
            return sql;
        }


        /// <summary>
        /// Elements the exists at.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="position">The position.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool ElementExistsAt<TEntity>(this IQueryable<TEntity> query, int position)
        {
            try
            {
                var val = query.Skip(position).First();

                return val != null;

            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// Smark Take
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="take">The take.</param>
        /// <returns>Tuple&lt;IQueryable&lt;TEntity&gt;, System.Boolean&gt;.</returns>
        public static Tuple<IQueryable<TEntity>, bool> SmartTake<TEntity>(this IQueryable<TEntity> query, int take)
        {
            var elementExistsAtLast = query.ElementExistsAt(take - 1);
            query = query.Take(take);

            return new Tuple<IQueryable<TEntity>, bool>(query, elementExistsAtLast);

        }

        /// <summary>
        /// Privates the specified private field.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="privateField">The private field.</param>
        /// <returns>System.Object.</returns>
        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
        /// <summary>
        /// Privates the specified private field.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <param name="privateField">The private field.</param>
        /// <returns>T.</returns>
        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

    }
}
