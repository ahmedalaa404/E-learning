using E_Learning.Core.Models.Identity;
using E_Learning.Repository.Data;
using E_Learning.Repository.Identity;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Helper
{
    public class DbInitializer
    {
        //public static async Task InitializaDbAsync(WebApplication app)
        //{
        //    using (var scope = app.Services.CreateScope())
        //    {
        //        var service = scope.ServiceProvider;
        //        var LogerFactory = service.GetRequiredService<ILoggerFactory>();

        //        try
        //        {
        //            //Create DB if it does'n Exist
        //            var context = service.GetRequiredService<LearningDbContext>();
        //            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                    
        //            //Apply Seeding
                    
        //            await IdentityDataContextSeed.SeedUsersAsync(userManager);
        //        }
        //        catch (Exception ex)
        //        {

        //            var logger = LogerFactory.CreateLogger<Program>();
        //            logger.LogError(ex.Message);
        //        }

        //    }
        //}
    }
}
