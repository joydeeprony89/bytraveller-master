using ByTravellerAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.Extensions
{
    /// <summary>
    /// Implementation of extension methods for Action results
    /// </summary>
    public static class ActionResultExtension
    {
        /// <summary>
        /// Extension method to accept the model
        /// </summary>
        /// <param name="actionResult">The parameter is not used</param>
        /// <param name="model">model</param>
        /// <returns>BaseActionResult</returns>
        public static BaseActionResult WithModel(this BaseActionResult actionResult, object model)
        {
            actionResult.Model = model;
            return actionResult;
        }

        /// <summary>
        /// Extension method to accept the HttpStatusCode
        /// </summary>
        /// <param name="actionResult">The parameter is not used</param>
        /// <param name="httpStatusCode">HttpStatusCode</param>
        /// <returns>BaseActionResult</returns>
        public static BaseActionResult WithHttpStatusCode(this BaseActionResult actionResult, HttpStatusCode httpStatusCode)
        {
            actionResult.HttpStatusCode = httpStatusCode;
            return actionResult;
        }

    }
}
