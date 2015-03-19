using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace Sett.DataAccess.Extensions
{
    public static class WhereExtension
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, string whereExpression)
            where T : class
        {
            if (whereExpression == null)
            {
                return queryable;
            }

            var whereItems = whereExpression.Split(':');

            if (whereItems[1] == "is"){
                whereItems[1] = "=";
            }

            whereItems[2] = string.Format("\"{0}\"", whereItems[2]);

            return queryable.Where(string.Join("", whereItems));
        }
    }
}
