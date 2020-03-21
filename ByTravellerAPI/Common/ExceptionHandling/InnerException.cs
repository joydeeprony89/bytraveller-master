using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ByTravellerAPI.Common.ExceptionHandling
{
    [DataContract, XmlRoot]
    public class InnerException
    {
        /// <summary>
        /// Gets or sets ClassName
        /// </summary>
        [XmlElement, DataMember(Name = "className")]
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        [XmlElement, DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets StackTrace
        /// </summary>
        [XmlElement, DataMember(Name = "stackTrace")]
        public string StackTrace { get; set; }
    }
}
