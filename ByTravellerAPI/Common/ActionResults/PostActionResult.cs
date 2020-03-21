using ByTravellerAPI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.ActionResults
{
    public class PostActionResult : BaseActionResult
    {
        public PostActionResult(HttpRequestMessage request)
            :base(request)
        {
            this.HttpStatusCode = System.Net.HttpStatusCode.Created;
        }

        public override HttpResponseMessage CreateResponse(CancellationToken cancellationToken)
        {
            if (this.HttpResponseMessage != null)
            {
                return this.HttpResponseMessage;
            }
            var response = base.CreateResponse(cancellationToken);
            response.RequestMessage = this.RequestMessage;
            return response;
        }
    }
}
