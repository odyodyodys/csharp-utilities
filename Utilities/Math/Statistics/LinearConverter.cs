using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Math.Statistics
{
    /* Converts a linear unit to another linear unit.
     * Example: Adjust values from 3000-3700 to 0-10 scale
     * The Adjusted value is (value - Zero)*Lambda
     */

    public class LinearConverter
    {
        public double Zero { set; get; }
        public double Lambda { set; get; }

        public LinearConverter()
        {
            Zero = 0;
            Lambda = 1;
        }

        public double Convert(double value)
        {
            return (value - Zero) * Lambda;
        }
    }
}