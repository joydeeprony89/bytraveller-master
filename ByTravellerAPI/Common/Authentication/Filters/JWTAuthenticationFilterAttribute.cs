using ByTravellerAPI.Common.ExceptionHandling;
using ByTravellerAPI.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using TokenService.Implementation;
using TokenService.Interface;

namespace ByTravellerAPI.Common.Authentication.Filters
{
    public class JWTAuthenticationFilterAttribute : AuthorizationFilterAttribute
    {
        private readonly ITokenManagerService tokenManagerService;

        public JWTAuthenticationFilterAttribute() :
            this(new TokenManagerService())
        {

        }

        public JWTAuthenticationFilterAttribute(ITokenManagerService tokenManagerService)
        {
            this.tokenManagerService = tokenManagerService;
        }
        public override void OnAuthorization(HttpActionContext filterContext)
        {

            if (!IsUserAuthorized(filterContext))
            {
                ShowAuthenticationError(filterContext);
                return;
            }
            base.OnAuthorization(filterContext);
        }

        public bool IsUserAuthorized(HttpActionContext actionContext)
        {
            var authHeader = FetchFromHeader(actionContext);
            if (authHeader != null)
            {
                string user = tokenManagerService.ValidateToken(authHeader);
                if (!string.IsNullOrEmpty(user))
                {
                    return true;
                }
            }
            return false;
        }

        private string FetchFromHeader(HttpActionContext actionContext)
        {
            string requestToken = null;

            var authRequest = actionContext.Request.Headers.Authorization;
            if (authRequest != null)
            {
                requestToken = authRequest.Parameter;
            }

            return requestToken;
        }

        private static void ShowAuthenticationError(HttpActionContext filterContext)
        {
            throw new BtException(HttpStatusCode.Unauthorized, ExceptionCode.HttpMethodUnableToAccess, ExceptionMessage.HTTP_METHOD_NOT_RECOGNIZED);
        }
    }
}
