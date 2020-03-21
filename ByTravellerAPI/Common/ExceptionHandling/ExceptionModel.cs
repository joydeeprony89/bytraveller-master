using ByTravellerAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ByTravellerAPI.Common.ExceptionHandling
{
    public class ExceptionModel : BaseExceptionModel
    {
        /// <summary>
        /// Gets or sets InnerException
        /// </summary>
        [DataMember(Name = "innerException"), XmlElement]
        public InnerException InnerException { get; set; }

        /// <summary>
        /// Gets or sets StackTrace
        /// </summary>
        [DataMember(Name = "stackTrace"), XmlElement]
        public string StackTrace { get; set; }
    }
}
