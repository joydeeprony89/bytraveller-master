using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using Unity;

namespace ByTraveller.Core.Configuration
{
    public class ServiceLocatorSettings
    {
        private const string SECTION_NAME = "unity";

        /// <summary>
        /// Returns application configuration settings.
        /// </summary>
        protected UnityConfigurationSection GetConfigurationSection()
        {
            return ConfigurationManager.GetSection(SECTION_NAME) as UnityConfigurationSection;
        }

        /// <summary>
        /// Applies configuration settings to the specified container instance
        /// and registers framework level services.
        /// </summary>
        /// <param name="container">A container instance to configure.</param>
        /// <returns>An instance of <see cref="IUnityContainer"/>.</returns>
        protected virtual IUnityContainer RegisterServices(IUnityContainer container)
        {
            UnityConfigurationSection configurationSection = GetConfigurationSection();
            if (configurationSection != null && configurationSection.Containers.Count > 0)
            {
                container.LoadConfiguration(configurationSection);
            }

            return container;
        }

        /// <summary>
        /// Constructor for Unity container configuration.
        /// </summary>
        /// <param name="configurationTarget">Target configuration as IUnityContainer</param>
        /// <returns>IUnityContainer</returns>
        public IUnityContainer Configure(IUnityContainer configurationTarget)
        {
            return RegisterServices(configurationTarget);
        }
    }
}
