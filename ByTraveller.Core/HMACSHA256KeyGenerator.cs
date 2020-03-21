using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ByTraveller.Core
{
    public static class HMACSHA256KeyGenerator
    {
        public static readonly string key = Convert.ToBase64String(new HMACSHA256().Key);
    }
}
