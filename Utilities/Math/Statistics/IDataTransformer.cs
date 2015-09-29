using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Math.Statistics
{
    public interface IDataTransformer<DataType, ResultType>
    {
        /**
         * Applies the transformation logic and returns the result
         */
        ResultType Transform(DataType data);
    }
}
