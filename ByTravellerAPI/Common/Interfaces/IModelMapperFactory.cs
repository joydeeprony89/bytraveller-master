//---------------------------------------------------------------------------------------------
// <copyright file= IModelMapperFactory.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common
{
    /// <summary>
    /// Interface for the Model mapper factory
    /// </summary>
    public interface IModelMapperFactory
    {
        /// <summary>
        /// Returns the model mapper interface for the specific type
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <returns>IAwModelMapper</returns>
        IModelMapper<T> GetModelMapper<T>();

        /// <summary>
        /// Returns the model mapper interface for the specific type and name
        /// </summary>
        /// <param name="name">Name</param>
        /// <typeparam name="T">Model</typeparam>
        /// <returns>IAwModelMapper</re
        IModelMapper<T> GetModelMapper<T>(string name);
    }
}
