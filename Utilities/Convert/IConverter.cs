using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Convert
{
    public interface IConverter<type1, type2>
    {
        type1 Convert(type2 data);

        type2 Convert(type1 data);
    }
}
