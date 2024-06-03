using E_Learning.Core.Models;
using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Core.Interfaces.Services
{
    public interface ITokenService
    {
        //public string GenerateToken(ApplicationUser user);
        Task<string> CreateTokenAsync(AppUser User, UserManager<AppUser> UManager);

    }
}
