using ByTraveller.Business.Users;
using ByTraveller.Model.Models;
using ByTraveller.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByTraveller.BusinessImpl.Users
{
    /// <summary>
    /// All Business Operation related to users
    /// </summary>
    public class UsersBusiness : IUsersBusiness
    {

        private readonly IUserDataHandler userDataHandler;

        public UsersBusiness(IUserDataHandler userDataHandler)
        {
            this.userDataHandler = userDataHandler;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<CoreUsers> _users = new List<CoreUsers>
        {
            new CoreUsers { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };

        public async Task<CoreUsers> Authenticate(string username, string password)
        {
           return await Task.Run(() => _users.First(x => x.Username == username && x.Password == password));
        }

        public Task UpdateUserRefreshToken(string token)
        {
            return userDataHandler.UpdateUserRefreshToken(token);
        }
    }
}
