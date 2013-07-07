using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities.Events
{
    public delegate void EmptyEventHandler();
    public delegate void StringEventHandler(string value);
    public delegate void StringListEventHandler(List<string> values);
    public delegate void StringPairListEventHandler(List<KeyValuePair<string, string>> values);
}
