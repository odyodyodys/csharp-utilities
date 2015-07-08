using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace Utilities.UI
{
    internal static class ISynchronizeInvokeEx
    {
        /**
         * Invokes a method of a control
         */
        public static void InvokeIfRequired(this ISynchronizeInvoke control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(action, null);
            }
            else
            {
                action();
            }
        }
    }

    public static class MulticaseDelegateExtentions
    {
        /**
         * Safely raises any EventHandler event asynchronously (Doesn't need to be a ISynchronizeInvoke control (eg a UserControl).
         * @param sender The object raising the event (usually this)
         * @param e The EventArgs for this event
         * http://stackoverflow.com/a/6209619/245495
         */
        public static object Raise(this MulticastDelegate thisEvent, object sender, EventArgs e)
        {
            object retVal = null;

            MulticastDelegate threadSafeMulticastDelegate = thisEvent;
            if (threadSafeMulticastDelegate != null)
            {
                foreach (Delegate d in threadSafeMulticastDelegate.GetInvocationList())
                {
                    var synchronizeInvoke = d.Target as ISynchronizeInvoke;
                    if ((synchronizeInvoke != null) && synchronizeInvoke.InvokeRequired)
                    {
                        retVal = synchronizeInvoke.EndInvoke(synchronizeInvoke.BeginInvoke(d, new[] { sender, e }));
                    }
                    else
                    {
                        retVal = d.DynamicInvoke(new[] { sender, e });
                    }
                }
            }

            return retVal;
        }
    }
}
