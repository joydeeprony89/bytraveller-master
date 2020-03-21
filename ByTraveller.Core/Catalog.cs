//---------------------------------------------------------------------------------------------
// <copyright file= Catalog.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using Unity;

namespace ByTraveller.Core
{
    /// <summary>
    /// Provides a catalog metaphor to help "bootstrap" applications when they start.
    /// </summary>
    public abstract class Catalog
    {
        protected IUnityContainer _container;

        internal void ProcessCatalog(IUnityContainer container)
        {
            _container = container;
            try
            {
                Initialize();
            }
            finally
            {
                _container = null;
            }
        }

        /// <summary>
        /// Called by <see cref="ServiceLocator"/> when a catalog instance is
        /// added.
        /// </summary>
        protected virtual void Initialize()
        {
        }

        /// <summary>
        /// Registers a service instance with the service locator.
        /// </summary>
        /// <typeparam name="TService">The type of service.</typeparam>        
        /// <typeparam name="TServiceImpl">The type that implements the service.</typeparam>        
        protected void RegisterServiceType<TService, TServiceImpl>()
        {
            _container.RegisterType(typeof(TService), typeof(TServiceImpl));
        }
    }
}
