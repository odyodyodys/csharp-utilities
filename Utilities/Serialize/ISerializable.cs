using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Serialize
{
    public interface ISerializable
    {
        string ParseToString();
        void ParseFromString(string textToParse);
    }
}
