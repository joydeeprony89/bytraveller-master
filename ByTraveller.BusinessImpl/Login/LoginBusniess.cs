//---------------------------------------------------------------------------------------------
// <copyright file= LoginBusniess.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using ByTraveller.Business.Login;
using ByTraveller.Model.Models;
using ByTraveller.Provider;

namespace ByTraveller.BusinessImpl.Login
{
    public class LoginBusniess : ILoginBusiness
    {
        private readonly ILoginDataHandler loginDataHandler;

        public LoginBusniess(ILoginDataHandler loginDataHandler)
        {
            this.loginDataHandler = loginDataHandler;
        }
        public bool SignIn(User user)
        {
            return loginDataHandler.SignIn(user);
        }

        public bool SignUp(User user)
        {
            return loginDataHandler.SignUp(user);
        }
    }
}
