//---------------------------------------------------------------------------------------------
// <copyright file= UserAuthenticationController.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ByTraveller.Model.Models;
using ByTraveller.Business.Login;
using TokenService;
using ByTravellerAPI.Common.ActionResults;
using ByTravellerAPI.Base;
using ByTravellerAPI.Common.Factory;
using ByTravellerAPI.Common.Extensions;
using TokenService.Interface;
using ByTraveller.Business.Users;
using ByTravellerAPI.Common.Authentication.Filters;

namespace ByTravellerAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [JWTAuthenticationFilterAttribute]
    public class UserAuthenticationController : BaseApiController
    {
        private readonly ILoginBusiness loginBusiness;
        private readonly ITokenManagerService tokenManagerService;
        private readonly IUsersBusiness usersBusiness;

        /// <summary>
        /// Create an instance of UserAuthenticationController
        /// </summary>
        /// <param name="loginBusiness"></param>
        /// <param name="tokenManagerService"></param>
        /// <param name="usersBusiness"></param>
        public UserAuthenticationController(ILoginBusiness loginBusiness, ITokenManagerService tokenManagerService, IUsersBusiness usersBusiness)
        {
            this.loginBusiness = loginBusiness;
            this.tokenManagerService = tokenManagerService;
            this.usersBusiness = usersBusiness;
        }

        [HttpPost]
        public Task<BaseActionResult> SignIn(User user)
        {
            string token = string.Empty;
            string refreshToken = string.Empty;
            bool result = loginBusiness.SignIn(user);
            if (result)
            {
                token = tokenManagerService.GenerateAccessToken(user.Email);
                refreshToken = tokenManagerService.GenerateRefreshToken();
                usersBusiness.UpdateUserRefreshToken(refreshToken);
            }
            return Task.FromResult<BaseActionResult>(ActionResultFactory.GetActionResult(this.Request).WithModel(token));
        }

        [HttpPost]
        public bool SignUp(User user)
        {
            return loginBusiness.SignUp(user);
        }
    }
}