using ByTravellerAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.ExceptionHandling
{
    public class BtException : Exception
    {
        /// <summary>
        /// Gets or sets ErrorCode
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public new object Message { get; set; }

        /// <summary>
        /// Gets or sets HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets InnerException
        /// </summary>
        public new Exception InnerException { get; set; }

        /// <summary>
        /// Initializes a new instance of the BtException class. 
        /// </summary>
        /// <param name="httpStatusCode">HttpStatusCode</param>
        /// <param name="errorCode">integer</param>
        /// <param name="message">string</param>
        /// <param name="links">List of Links</param>
        /// <param name="innerException">Exception</param>
        public BtException(HttpStatusCode httpStatusCode, int errorCode, object message = null, Exception innerException = null)
            : base(message?.ToString(), innerException)
        {
            this.ErrorCode = errorCode;
            this.HttpStatusCode = httpStatusCode;
            this.Message = message;
        }

        /// <summary>
        /// Converter to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            // TODO: Convert to JSON while returning back
            if (this.InnerException != null)
            {
                return string.Format("ErrorCode:{0} Message:{1} InnerException:{2}", this.ErrorCode, this.Message, this.InnerException);
            }

            return string.Format("ErrorCode:{0} Message:{1} Stack Trace:{2}", this.ErrorCode, this.Message, this.StackTrace);
        }

        /// <summary>
        /// Method to return the exception model from exception
        /// </summary>
        /// <returns>AwExceptionModel</returns>
        public ExceptionModel GetExceptionModel()
        {
            var exceptionModel = new ExceptionModel();
            exceptionModel.InnerException = this._GetInnerException(this.InnerException);
            exceptionModel.ErrorCode = this.ErrorCode;
            exceptionModel.Message = this.Message;
            exceptionModel.StackTrace = this.StackTrace;
            return exceptionModel;
        }

        /// <summary>
        /// Method to return the base exception model from exception
        /// </summary>
        /// <returns>AwBaseExceptionModel</returns>
        public BaseExceptionModel GetBaseExceptionModel()
        {
            var exceptionModel = new BaseExceptionModel();
            exceptionModel.ErrorCode = this.ErrorCode;
            exceptionModel.Message = this.Message;
            return exceptionModel;
        }

        /// <summary>
        /// Method to return the inner exception from exception
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>InnerException</returns>
        private InnerException _GetInnerException(Exception exception)
        {
            if (exception == null)
            {
                return null;
            }

            var innerExcetion = new InnerException
            {
                ClassName = exception.GetType().Name,
                Message = exception.Message,
                StackTrace = exception.StackTrace
            };

            return innerExcetion;
        }
    }
}
