using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Collections
{
    public static class EnumerableExtensions
    {
        // Source: http://stackoverflow.com/a/1287572/245495
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            T[] elements = source.ToArray();
            for (int i = elements.Length - 1; i >= 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                // ... except we don't really need to swap it fully, as we can
                // return it immediately, and afterwards it's irrelevant.
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }

        // The math median of a collection. http://stackoverflow.com/a/10738416/245495
        public static double? Median<TColl, TValue>(this IEnumerable<TColl> source, Func<TColl, TValue> selector)
        {
            return source.Select<TColl, TValue>(selector).Median();
        }
        public static double? Median<T>(this IEnumerable<T> source)
        {
            if (Nullable.GetUnderlyingType(typeof(T)) != null)
            {
                source = source.Where(x => x != null);
            }

            int count = source.Count();
            if (count == 0)
            {
                return null;
            }

            source = source.OrderBy(n => n);

            int midpoint = count / 2;
            if (count % 2 == 0)
            {
                return (System.Convert.ToDouble(source.ElementAt(midpoint - 1)) + System.Convert.ToDouble(source.ElementAt(midpoint))) / 2.0;
            }
            else
            {
                return System.Convert.ToDouble(source.ElementAt(midpoint));
            }
        }
    }
}
