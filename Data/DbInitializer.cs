
using WebAppRESTAPI.Function;

namespace WebAppRESTAPI.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(AppIdentityDbContext userContext, ApplicationDbContext context, InitializeAppData initializeAppData)
        {
            context.Database.EnsureCreated();
            userContext.Database.EnsureCreated();
            //check for users
            if (userContext.Users.Any())
            {
                return; //if user is not empty, DB has been seed
            }

            if (context.Products.Any() || context.Companies.Any())
            {
                return; //if any table is not empty, DB has been seed
            }

            //init app data
            await initializeAppData.Run();
        }
    }
}
