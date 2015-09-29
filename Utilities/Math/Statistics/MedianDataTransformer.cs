using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Collections;

namespace Utilities.Math.Statistics
{
    /**
     * Given a collection of numerical data it returns the median.
     */
    internal class MedianDataTransformer<DataType> : IDataTransformer<IEnumerable<DataType>, double?>
    {
        public double? Transform(IEnumerable<DataType> data)
        {
            double? result = null;
            if (data.Any())
            {
                result = data.Median();
            }
            return result;
        }
    }
}
