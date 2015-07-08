using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Events
{
    public class EventArgs<Type>: EventArgs
    {
        public Type Value { set; get; }
        public EventArgs(Type value)
        {
            Value = value;
        }
    }
}
