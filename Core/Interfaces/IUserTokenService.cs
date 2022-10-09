using System;
using Core.Entities.Identity;

namespace Core.Interfaces
{
    public interface IUserTokenService
    {
        string CreateUserToken(AppUser user);    
    }
}
