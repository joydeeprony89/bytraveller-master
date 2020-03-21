using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ByTraveller.Provider
{
    public interface IUserDataHandler
    {
        Task UpdateUserRefreshToken(string token);
    }
}
