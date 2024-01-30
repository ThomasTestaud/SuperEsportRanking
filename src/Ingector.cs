using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class Ingector
    {
        private readonly Dictionary<Type, Func<object>> transientServices = new Dictionary<Type, Func<object>>();
        private readonly Dictionary<Type, object> singletonServices = new Dictionary<Type, object>();
        private readonly Dictionary<Type, Func<object>> singletonFactories = new Dictionary<Type, Func<object>>();

        public void RegisterTransient<TService>(Func<TService> implementationFactory) where TService : class
        {
            transientServices[typeof(TService)] = () => implementationFactory();
        }

        public void RegisterSingleton<TService>(TService implementation) where TService : class
        {
            singletonServices[typeof(TService)] = implementation;
        }

        public void RegisterSingleton<TService>(Func<TService> implementationFactory) where TService : class
        {
            singletonFactories[typeof(TService)] = () => implementationFactory();
        }

        public TService Resolve<TService>() where TService : class
        {
            return (TService)Resolve(typeof(TService));
        }

        private object Resolve(Type serviceType)
        {
            // Check for singleton instance
            if (singletonServices.TryGetValue(serviceType, out var singletonInstance))
            {
                return singletonInstance;
            }

            // Check for singleton factory
            if (singletonFactories.TryGetValue(serviceType, out var singletonFactory))
            {
                var instance = singletonFactory();
                singletonServices[serviceType] = instance; // Store for future requests
                return instance;
            }

            // Check for transient service
            if (transientServices.TryGetValue(serviceType, out var transientFactory))
            {
                return transientFactory();
            }

            throw new InvalidOperationException($"No service registered for type {serviceType}");
        }
    }
}
