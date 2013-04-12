using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Pattern;
using Utilities.Math;

namespace Utilities.Convert
{
    public class MathUnitToStringConverter:IConverter<MathUnitType, string>
    {

        #region Constructors
        private MathUnitToStringConverter()
        {

        }
        public static MathUnitToStringConverter Instance
        {
            get
            {
                return Singleton<MathUnitToStringConverter>.Instance;
            }
        }
        #endregion

        #region IConverter Members

        public string Convert(MathUnitType type)
        {
            string result = string.Empty;

            switch (type)
            {
                case MathUnitType.hz:
                    result = "Hz";
                    break;
                case MathUnitType.percent:
                    result = "%";
                    break;
                case MathUnitType.ms:
                    result = "ms";
                    break;
                case MathUnitType.db:
                    result = "db";
                    break;
                case MathUnitType.ratio:
                    result = "x:1";
                    break;
                case MathUnitType.boolean:
                    result = "bool";
                    break;
                default:
                    break;
            }

            return result;
        }
        public MathUnitType Convert(string data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
