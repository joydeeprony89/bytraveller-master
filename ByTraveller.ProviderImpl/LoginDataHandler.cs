//---------------------------------------------------------------------------------------------
// <copyright file= LoginDataHandler.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using ByTraveller.Model.Models;
using ByTraveller.Provider;
using ByTraveller.EntityFramework;

namespace ByTraveller.ProviderImpl
{
    public class LoginDataHandler : ILoginDataHandler
    {
        private readonly ApplicationContext applicationContext;

        public LoginDataHandler(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public LoginDataHandler()
        {

        }
        public bool SignIn(User user)
        {
            throw new NotImplementedException();
        }

        public bool SignUp(User user)
        {
            applicationContext.Users.Add(user);
            applicationContext.SaveChanges();
            return true;
        }
    }
}
