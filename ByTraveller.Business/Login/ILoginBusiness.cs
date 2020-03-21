//---------------------------------------------------------------------------------------------
// <copyright file= ILoginBusiness.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using ByTraveller.Model.Models;

namespace ByTraveller.Business.Login
{
    public interface ILoginBusiness
    {
        bool SignIn(User user);

        bool SignUp(User user);
    }
}
