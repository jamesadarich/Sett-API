using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Sett.DataAccess.Extensions
{
    public static class SortExtension
    {
        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> queryable, string sortExpression)
            where T : class
        {
            if (sortExpression == null)
            {
                return queryable.OrderBy(x => 0);
            }


            var propertyName = "";
            var sortItems = sortExpression.Split(',');
            IOrderedQueryable<T> orderedList = null;
            for (var i = 0; i < sortItems.Length; i++)
            {
                var direction = SortDirection.Ascending;

                if (sortItems[i].EndsWith(" asc"))
                {
                    propertyName = sortItems[i].Remove(sortItems[i].Length - 4);
                    direction = SortDirection.Ascending;
                }
                else if (sortItems[i].EndsWith(" desc"))
                {
                    propertyName = sortItems[i].Remove(sortItems[i].Length - 5);
                    direction = SortDirection.Descending;
                }
                else
                {
                    throw new ArgumentException("sortString");
                }

                var param = Expression.Parameter(typeof(T), typeof(T).ToString().ToLower()[0].ToString());
                var parts = propertyName.Split('.');

                Expression parent = param;

                foreach (var part in parts)
                {
                    parent = Expression.Property(parent, part);
                }

                if (i > 0)
                {
                    if (direction == SortDirection.Descending)
                    {
                        if (parent.Type == typeof(DateTime))
                        {
                            orderedList = orderedList.ThenByDescending(Expression.Lambda<Func<T, DateTime>>(parent, param));
                        }
                        else if (parent.Type == typeof(int))
                        {
                            orderedList = orderedList.ThenByDescending(Expression.Lambda<Func<T, int>>(parent, param));
                        }
                        else
                        {
                            orderedList = orderedList.ThenByDescending(Expression.Lambda<Func<T, object>>(parent, param));
                        }
                    }
                    else
                    {
                        if (parent.Type == typeof(DateTime))
                        {
                            orderedList = orderedList.ThenBy(Expression.Lambda<Func<T, DateTime>>(parent, param));
                        }
                        else if (parent.Type == typeof(int))
                        {
                            orderedList = orderedList.ThenBy(Expression.Lambda<Func<T, int>>(parent, param));
                        }
                        else
                        {
                            orderedList = orderedList.ThenBy(Expression.Lambda<Func<T, object>>(parent, param));
                        }
                    }
                }
                else
                {

                    if (direction == SortDirection.Descending)
                    {
                        if (parent.Type == typeof(DateTime))
                        {
                            orderedList = queryable.OrderByDescending(Expression.Lambda<Func<T, DateTime>>(parent, param));
                        }
                        else if (parent.Type == typeof(int))
                        {
                            orderedList = queryable.OrderByDescending(Expression.Lambda<Func<T, int>>(parent, param));
                        }
                        else
                        {
                            orderedList = queryable.OrderByDescending(Expression.Lambda<Func<T, object>>(parent, param));
                        }
                    }
                    else
                    {
                        if (parent.Type == typeof(DateTime))
                        {
                            orderedList = queryable.OrderBy(Expression.Lambda<Func<T, DateTime>>(parent, param));
                        }
                        else if (parent.Type == typeof(int))
                        {
                            orderedList = queryable.OrderBy(Expression.Lambda<Func<T, int>>(parent, param));
                        }
                        else
                        {
                            orderedList = queryable.OrderBy(Expression.Lambda<Func<T, object>>(parent, param));
                        }
                    }
                }
            }
            return orderedList;
        }


        private class SortSelector<T, P> : SortSelector
        {
            public Expression<Func<T, P>> Selector = null;
            public SortDirection Direction = SortDirection.Ascending;

            public SortSelector(Expression<Func<T, P>> selector, SortDirection direction)
            {
                Selector = selector;
                Direction = direction;
            }
        }

        private class SortSelector
        {
            public SortDirection GetDirection()
            {
                return SortDirection.Ascending;
            }
        }

        public enum SortDirection
        {
            Ascending,
            Descending
        }
    }
}