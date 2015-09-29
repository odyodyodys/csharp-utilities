using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Convert;

namespace Utilities.Serialize
{
    public class ValueSerializer
    {
        public static string DoInt(uint digits, int value)
        {
            string serialized = string.Empty;
            try
            {
                string positiveNumericFormat = new string('0', (int)digits);
                string negativeNumericFormat = new string('0', (int)digits - 1);

                serialized = string.Format("{0:" + positiveNumericFormat + ";-" + negativeNumericFormat + "}", value);
            }
            catch (System.Exception e)
            {
                throw new ConverterException(e.Message);
            }
            return serialized;
        }
        public static string DoFloat(uint digits, int precision, float value)
        {
            string serialized = string.Empty;
            try
            {
                string precisionFormat = new string('0', precision);
 
                string positiveNumericFormat = new string('0', (int)digits);
                string negativeNumericFormat = new string('0', (int)digits - 1);
 
                serialized = string.Format("{0:" + positiveNumericFormat.Substring(1 + precision) + "." + precisionFormat +
                                           ";-" + negativeNumericFormat.Substring(1 + precision) + "." + precisionFormat +
                                           "}", value).Replace(',', '.');
            }
            catch (System.Exception e)
            {
                throw new ConverterException(e.Message);
            }
            return serialized;
        }
        public static string DoBin(bool value)
        {
            string serialized = string.Empty;
            try
            {
                if (value)
                {
                    serialized = "1";
                }
                else
                {
                    serialized = "0";
                }
            }
            catch (System.Exception e)
            {
                throw new ConverterException(e.Message);
            }
            return serialized;
        }
    }
}
