//---------------------------------------------------------------------------------------------
// <copyright file= IModelMapper.cs company= ByTraveller>
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
    /// Interface for the Model Mapper
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    public interface IModelMapper<T>
    {
        /// <summary>
        /// Executes the mapping between source and destination resource
        /// </summary>
        /// <typeparam name="T1">source type</typeparam>
        /// <typeparam name="T2">destination type</typeparam>
        /// <param name="t">source object</param>
        /// <returns>destination object</returns>
        T2 Map<T1, T2>(T1 t);
    }
}
