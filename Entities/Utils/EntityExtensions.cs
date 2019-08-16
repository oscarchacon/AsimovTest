using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities.Utils
{
    public static class EntityExtensions
    {

        public static bool IsObjectNull<T>(this T entity) where T : class
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this IEntity entity)
        {
            return entity.Id.Equals(Guid.Empty);
        }

        public static bool IsListObjectNull<T>(this IEnumerable<T> entityList) where T : class
        {
            return entityList == null;
        }

        public static bool IsEmptyListObject<T>(this IEnumerable<T> entityList) where T : class
        {
            return !entityList.Any();
        }
    }
}
