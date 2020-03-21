using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.Utils
{
    /// <summary>
    /// Contains all application error codes in constants
    /// </summary>
    public static class ExceptionCode
    {
        /// <summary>
        /// AW Error code for Http method not recognized.
        /// </summary>
        public const int HttpMethodNotRecognized = 1000;

        /// <summary>
        /// AW Error code for Http method not able to access.
        /// </summary>
        public const int HttpMethodUnableToAccess = 1001;
    }
}
