using asp_ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace asp_ng.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;
            if (queryObj.IsSortAscending)
            {
                query = query.OrderBy(columnsMap[queryObj.SortBy]);
            }
            else
            {
                query = query.OrderByDescending(columnsMap[queryObj.SortBy]);
            }

            return query;
        }
    }
}
