using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace TokenService.Interface
{
    /// <summary>
    /// Interface for Token Manger Service
    /// </summary>
    public interface ITokenManagerService
    {
        string GenerateAccessToken(string username);
        ClaimsPrincipal GetPrincipal(string token);
        string GenerateRefreshToken();
        string ValidateToken(string token);
    }
}
