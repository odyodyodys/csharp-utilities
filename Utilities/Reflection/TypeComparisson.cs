using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Reflection
{
    public class TypeComparisson
    {
        public static bool AreExactSameType(object a, object b)
        {
            bool sameType = false;
            Type aType = a.GetType();
            Type bType = b.GetType();

            if(aType.IsAssignableFrom(bType) || bType.IsAssignableFrom(aType))
            {
                sameType = true;
            }

            return sameType;
        }
    }
}
