using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationWinForm
{
    public class SingletonGenericClass<T> where T : class, new()
    {
        private static readonly object controlObject = new object();
        private static T instance = null;

        private SingletonGenericClass() { }

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (controlObject)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
        public static T ResetInstance()
        {
            instance = null;
            lock (controlObject)
            {
                return instance = new T();
            }
        }
    }
}
