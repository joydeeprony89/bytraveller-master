using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.Utils
{
    /// <summary>
    /// Contains custom error messages as constants
    /// </summary>
    public static class ExceptionMessage
    {
        /// <summary>
        /// Internal Server Error
        /// </summary>
        public const string HTTP_METHOD_NOT_RECOGNIZED = "Http Method not recognized";

        /// <summary>
        /// Internal Server Error
        /// </summary>
        public const string HTTP_METHOD_NOT_ABLE_TO_ACCESS = "Unable to access, Please login again";
    }
}
