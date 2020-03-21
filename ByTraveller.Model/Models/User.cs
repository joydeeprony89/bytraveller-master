//---------------------------------------------------------------------------------------------
// <copyright file= User.cs company= ByTraveller>
// Copyright © 2019 ByTraveller. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace ByTraveller.Model.Models
{
    public class User : BaseModel
    {
        public int UserId { get; set; }
        public string Email;
        public string Name;
        public string Provider;
        public string ProviderId;
        public string ProviderPic;
        public string Token;
        public string Password;
    }
}
