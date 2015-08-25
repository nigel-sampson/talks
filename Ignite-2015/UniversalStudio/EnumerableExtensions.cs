using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversalStudio
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, params T[] exceptions)
        {
            return items.Except(exceptions.AsEnumerable());
        }
    }
}
