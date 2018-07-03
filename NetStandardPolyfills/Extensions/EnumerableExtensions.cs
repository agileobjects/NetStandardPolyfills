using System;
using System.Collections.Generic;

namespace AgileObjects.NetStandardPolyfills.Extensions
{
    internal static class EnumerableExtensions
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate.Invoke(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Project<TItem, TResult>(
            this IEnumerable<TItem> items,
            Func<TItem, TResult> projector)
        {
            foreach (var item in items)
            {
                yield return projector.Invoke(item);
            }
        }
    }
}
