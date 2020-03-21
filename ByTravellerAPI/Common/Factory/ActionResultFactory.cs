using ByTravellerAPI.Base;
using ByTravellerAPI.Common.ActionResults;
using ByTravellerAPI.Common.ExceptionHandling;
using ByTravellerAPI.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ByTravellerAPI.Common.Factory
{
    public static class ActionResultFactory
    {
        public static BaseActionResult GetActionResult(HttpRequestMessage request)
        {
            switch (request.Method.Method)
            {
                case BtConstants.HTTP_POST: return new PostActionResult(request);
            }

            throw new BtException(System.Net.HttpStatusCode.BadRequest, ExceptionCode.HttpMethodNotRecognized, ExceptionMessage.HTTP_METHOD_NOT_RECOGNIZED);
        }
    }
}
