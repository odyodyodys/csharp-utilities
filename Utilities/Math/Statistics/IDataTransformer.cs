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
         * Applies the probability logic and returns the result
         */
        ResultType Value(DataType data);
    }
}
