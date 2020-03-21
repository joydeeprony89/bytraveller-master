using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocator;
using ByTraveller.Core.Configuration;
using Microsoft.Practices.Unity;

namespace ByTraveller.Core
{
    /// <summary>
    /// Service Locator pattern (Singleton) implementation.
    /// </summary>
    public sealed class ServiceLocator : IServiceLocator
    {
        /// <summary>
        /// Gets the global service locator instance from <see cref="ApplicationContext"/>
        /// </summary>
        public static ServiceLocator Current => lazyInstance.Value;

        private static ServiceLocatorSettings _settings;
        private readonly IUnityContainer _container;

        /// <summary>
        /// Settings for the service locator. If you assign this, it must be the VERY FIRST ACTION in the program,
        /// or at least before the ServiceLocator is first retrieved.
        /// </summary>
        public static ServiceLocatorSettings Settings
        {
            get
            {
                return _settings ?? (_settings = new ServiceLocatorSettings());
            }
            set
            {
                if (value != null)
                {
                    //Ignore ServiceLocatorSettings if it is been used after _settings already exists
                    if (_settings != null && value.GetType() == typeof(ServiceLocatorSettings))
                    {
                        return;
                    }
                    _settings = value;
                }
            }
        }

        /// <summary>
        /// Creates a new instance of <see cref="ServiceLocator"/> for the specified settings object.
        /// </summary>
        private ServiceLocator(ServiceLocatorSettings configurationSettings)
        {
            _container = configurationSettings.Configure(new UnityContainer());
        }

        /// <summary>
        /// the lazy instance of ServiceLocator
        /// </summary>
        private static Lazy<ServiceLocator> lazyInstance = new Lazy<ServiceLocator>(() => new ServiceLocator(Settings));

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>()
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public object GetInstance(Type serviceType, string key)
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>()
        {
            throw new NotImplementedException();
        }

        public TService GetInstance<TService>(string key)
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers a <see cref="Catalog"/> object with the service locator.
        /// </summary>
        public ServiceLocator AddCatalog(Catalog catalog)
        {
            catalog.ProcessCatalog(_container);
            return this;
        }
    }
}
