using ByTraveller.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ByTraveller.Business.Users
{
    /// <summary>
    /// All Business Operation related to users
    /// </summary>
    public interface IUsersBusiness
    {
        Task<CoreUsers> Authenticate(string username, string password);

        Task UpdateUserRefreshToken(string token);
    }
}
