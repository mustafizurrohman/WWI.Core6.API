using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
        /// <param name="source">The large IQueryable to split</param>
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
        /// <returns></returns>
        public static string ToSql<TEntity>(this IQueryable<TEntity> query) where TEntity : class
        {
            var enumerator = query.Provider.Execute<IEnumerable<TEntity>>(query.Expression).GetEnumerator();
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
        /// <param name="position"></param>
        /// <returns></returns>
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
        /// <returns></returns>
        public static Tuple<IQueryable<TEntity>, bool> SmartTake<TEntity>(this IQueryable<TEntity> query, int take)
        {
            var elementExistsAtLast = query.ElementExistsAt(take - 1);
            query = query.Take(take);

            return new Tuple<IQueryable<TEntity>, bool>(query, elementExistsAtLast);

        }

        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);
        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(obj);

    }
}
