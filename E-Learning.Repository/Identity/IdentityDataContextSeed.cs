using E_Learning.Core.Models;
using E_Learning.Core.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Repository.Identity
{
    public class IdentityDataContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    UserName = "AlaaMahmoud",
                    Email = "Alaa@Gmail.Com",
                    Fname = "Alaa Mahmoud",
                    Lname = "Alaa Mahmoud",
                };

       var resulte=         await userManager.CreateAsync(user, "P@ssw0rd12345");
            }

        }
    }
}
