//---------------------------------------------------------------------------------------------
// <copyright file= IocContainer.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace ByTravellerAPI.Common
{
    [ExcludeFromCodeCoverage]
    public static class IocContainer
    {
        /// <summary>
        /// Private member
        /// </summary>
        private static IUnityContainer unityContainer = new UnityContainer();

        /// <summary>
        /// Gets the IUnityContainer
        /// </summary>
        public static IUnityContainer UnityContainer
        {
            get
            {
                return unityContainer;
            }
        }

        /// <summary>
        /// Resolves the type
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <returns>T</returns>
        public static T Resolve<T>()
        {
            try
            {
                object resolved = UnityContainer.Resolve<T>();
                if (resolved != null)
                {
                    return (T)resolved;
                }

                return default(T);
            }
            catch (ResolutionFailedException)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Resolves to a particular type
        /// </summary>
        /// <param name="t">Type</param>
        /// <returns>object</returns>
        public static object Resolve(Type t)
        {
            try
            {
                object resolved = UnityContainer.Resolve(t);
                if (resolved != null)
                {
                    return resolved;
                }

                return null;
            }
            catch (ResolutionFailedException) when (t.IsWebApiDependency())
            {
                return null;
            }
        }
    }
}
