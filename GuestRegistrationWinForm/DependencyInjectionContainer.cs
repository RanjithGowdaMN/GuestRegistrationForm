using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuestRegistrationWinForm
{
    public class DependencyInjectionContainer
    {
        private readonly Dictionary<Type, object> _dependencies;

        public DependencyInjectionContainer()
        {
            _dependencies = new Dictionary<Type, object>();
        }

        public void Register<T>(T implementation)
        {
            _dependencies[typeof(T)] = implementation;
        }

        public T Resolve<T>()
        {
            if (!_dependencies.ContainsKey(typeof(T)))
            {
                throw new InvalidOperationException($"Type '{typeof(T)}' is not registered in the container.");
            }

            return (T)_dependencies[typeof(T)];
        }
    }
}
