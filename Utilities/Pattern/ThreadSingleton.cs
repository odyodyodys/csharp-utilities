using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Pattern
{
/*
     * Description: Applies the Singleton pattern to a class, providing one instance per thread.
     * Usage: 
     *  private ClassA(){} // constructor
     *  public static ClassA Instance // property
     *  {
     *      get { return ThreadSingleton<ClassA>.Instance; }
     *  }
    */

    internal static class ThreadSingleton<T> where T : class
    {
        [ThreadStatic]
        private static volatile T _instance;
        private static object _lock = new object();

        static ThreadSingleton()
        {
        }

        public static T Instance
        {
            get
            {
                try
                {
                    if (_instance == null)
                        lock (_lock)
                        {
                            if (_instance == null)
                            {
                                _instance = typeof(T).InvokeMember(typeof(T).Name, BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, null, null, null) as T;
                            }
                        }

                    return _instance;
                }
                catch (Exception e)
                {
                    throw new Exception(typeof(T).ToString() + " cannot be instantiated as a Thread Singleton. It is not a class." + Environment.NewLine + e.Message);
                }
            }
        }
    }
}
