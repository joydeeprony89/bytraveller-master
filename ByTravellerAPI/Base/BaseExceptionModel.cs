using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ByTravellerAPI.Base
{
    /// <summary>
    /// Base model for exception
    /// </summary>
    [Serializable, DataContract]
    [XmlRoot(ElementName ="ByTravellerFaultContract", Namespace ="www.bytraveller.com")]
    public class BaseExceptionModel
    {
        /// <summary>
        /// Application error code
        /// </summary>
        [DataMember(Name = "errorCode"), XmlElement]
        public int ErrorCode { get; set; }

        /// <summary>
        /// Friendly error message
        /// </summary>
        [DataMember(Name = "message"), XmlElement(Type = typeof(string))]
        public object Message { get; set; }

        /// <summary>
        /// TransactionId of the request
        /// </summary>
        [DataMember(Name = "activityId"), XmlElement]
        public Guid ActivityId { get; set; }
    }
}
