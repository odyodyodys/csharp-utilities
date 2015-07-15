using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Reflection
{
    internal static class ValueComparisson
    {
        /**
         * Generic comparer. Can be used like x == y when x,y are generic types.
         */
        public static bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
    }
}
