using System.Collections.Generic;
using System.Linq;

namespace InfiniteAxisUtilitySystem.Persistence
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> DefaultToEmptyIfNull<T>(this IEnumerable<T> source) =>
            source ?? Enumerable.Empty<T>();

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> items)
        {
            var hashSet = new HashSet<T>();

            if (items == null)
                return hashSet;

            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }
    }
}
