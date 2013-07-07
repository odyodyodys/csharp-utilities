using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Convert
{
    [global::System.Serializable]
    public class ConverterException : Exception
    {
        public ConverterException() { }
        public ConverterException(string message) : base(message) { }
        public ConverterException(string message, Exception inner) : base(message, inner) { }
        protected ConverterException(
          global::System.Runtime.Serialization.SerializationInfo info,
          global::System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
