//---------------------------------------------------------------------------------------------
// <copyright file= BaseApiController.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using ByTravellerAPI.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ByTravellerAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        ///// <summary>
        ///// Gets IAwModelMapperFactory
        ///// </summary>
        private static IModelMapperFactory modelMapperFactoryInterface;

        /// <summary>
        /// Initializes a new instance of the BaseApiController class
        /// </summary>
        public BaseApiController()
        {
            if (modelMapperFactoryInterface == null)
            {
                modelMapperFactoryInterface = IocContainer.Resolve<IModelMapperFactory>();
            }
        }

        /// <summary>
        /// Gets ModelMapperFactory
        /// </summary>
        protected IModelMapperFactory ModelMapperFactory => modelMapperFactoryInterface;
    }
}
