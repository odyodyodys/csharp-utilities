using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Math.Statistics
{
    public interface IDataAnalyzer<DataType, ResultType>
    {
        /**
         * Applies the probability logic and returns the result
         */
        ResultType Value(IEnumerable<DataType> data);
    }
}
