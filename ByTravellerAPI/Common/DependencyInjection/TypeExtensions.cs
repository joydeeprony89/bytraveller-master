//---------------------------------------------------------------------------------------------
// <copyright file= TypeExtensions.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace ByTravellerAPI.Common
{
    internal static class TypeExtensions
    {
        /// <summary>
        ///  Web api bootstrap type names.
        /// </summary>
        private static readonly List<string> BootstrapTypeNamespaces = new List<string>(
            new[]
                {
                    "System.Web.Http",
                    "System.Net.Http"
            });

        /// <summary>
        ///     A  type extension method that queries if 'type' is web API dependency by checking the namespace.
        /// </summary>
        /// <param name="type"> The type to act on. </param>
        /// <returns>
        ///     True if web API dependency, false if not.
        /// </returns>
        internal static bool IsWebApiDependency(this Type type)
        {
            return BootstrapTypeNamespaces.Any(s => type.Namespace.Contains(s)) || type == typeof(IValidatorFactory);
            //Explicitly adding typeof check for IValidatorFactory since FluentValidation has other types which should not be included in webapidependency.
        }
    }
}
