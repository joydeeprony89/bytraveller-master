
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ByTravellerAPI.Base
{
    /// <summary>
    /// Base class implementation for IHttpActionResult
    /// </summary>
    public class BaseActionResult : IHttpActionResult
    {
        /// <summary>
        /// Gets or sets the RequestMessage
        /// </summary>
        public HttpRequestMessage RequestMessage { get; set; }

        /// <summary>
        /// Gets or sets HttpStatusCode
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }

        /// <summary>
        /// Gets or sets HttpResponseMessage
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }

        /// <summary>
        /// Gets or sets Model
        /// </summary>
        public object Model { get; set; }

        /// <summary>
        /// Initializes a new instance of the BaseActionResult class
        /// </summary>
        /// <param name="requestMessage">HttpRequestMessage</param>
        public BaseActionResult(HttpRequestMessage requestMessage)
        {
            this.RequestMessage = requestMessage;
        }

        public virtual HttpResponseMessage CreateResponse(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(this.HttpStatusCode);
            response.RequestMessage = this.RequestMessage;
            return response;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(this.CreateResponse(cancellationToken));
        }
    }
}
