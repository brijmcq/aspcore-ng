using asp_ng.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace asp_ng.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<Vehicle> ApplyOrdering(this IQueryable<Vehicle> query, IQueryObject queryObj, Dictionary<string, Expression<Func<Vehicle, object>>> columnsMap)
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

        public static IQueryable<Vehicle> ApplyPaging(this IQueryable<Vehicle> query, IQueryObject queryObj)
        {
            if (queryObj.PageSize <= 0)
            {
                queryObj.PageSize = 10;
            }
            if (queryObj.Page <= 0)
            {
                queryObj.Page = 1;
            }

            return  query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
             
        }

    }
}
