using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Collections
{
    // ConcurrentQueue with fixed size. Based on http://stackoverflow.com/a/5852926/245495
    public class ConcurrentFixedSizedQueue<T> : ConcurrentQueue<T>
    {
        private object _lock;
        public int Limit { get; set; }

        public ConcurrentFixedSizedQueue()
        {
            _lock = new object();
        }

        public new void Enqueue(T obj)
        {
            base.Enqueue(obj);
            lock (_lock)
            {
                T overflow;
                while (base.Count > Limit && base.TryDequeue(out overflow)) ;
            }
        }
    }
}
