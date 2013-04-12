using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Utilities.Pattern
{
    /*
     * Description: Applies the Singleton pattern to a class.
     * Usage: 
     *  private ClassA(){} // constructor
     *  public static ClassA Instance // property
     *  {
     *      get { return Singleton<ClassA>.Instance; }
     *  }
    */

    public static class Singleton<T> where T : class
    {
        private static volatile T _instance;
        private static object _lock = new object();

        static Singleton()
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
                                _instance = typeof(T).InvokeMember(typeof(T).Name,
                                                                    BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic,
                                                                    null, null, null) as T;
                            }
                        }

                    return _instance;
                }
                catch (Exception e)
                {
                    throw new Exception(typeof(T).ToString() + " cannot be instantiated as a singleton. It is not a class." + Environment.NewLine + e.Message);
                }
            }
        }
    }
}
